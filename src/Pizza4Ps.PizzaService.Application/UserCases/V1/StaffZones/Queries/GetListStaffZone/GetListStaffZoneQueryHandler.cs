using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone
{
    public class GetListStaffZoneQueryHandler : IRequestHandler<GetListStaffZoneQuery, PaginatedResultDto<StaffZoneDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public GetListStaffZoneQueryHandler(IMapper mapper, IStaffZoneRepository StaffZoneRepository)
        {
            _mapper = mapper;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<PaginatedResultDto<StaffZoneDto>> Handle(GetListStaffZoneQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneRepository.GetListAsNoTracking(
                x => (request.ShiftStart == null || x.ShiftStart == request.ShiftStart)
                && (request.ShiftEnd == null || x.ShiftEnd == request.ShiftEnd)
                && (request.Note == null || x.Note == request.Note)
                && (request.StaffId == null || x.StaffId == request.StaffId)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffZoneDto>(result, totalCount);
        }
    }
}

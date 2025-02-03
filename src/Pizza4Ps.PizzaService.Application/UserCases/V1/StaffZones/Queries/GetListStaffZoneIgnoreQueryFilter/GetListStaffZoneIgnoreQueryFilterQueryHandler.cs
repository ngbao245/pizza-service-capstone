using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter
{
    public class GetListStaffZoneIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffZoneIgnoreQueryFilterQuery, PaginatedResultDto<StaffZoneDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public GetListStaffZoneIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffZoneRepository StaffZoneRepository)
        {
            _mapper = mapper;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<PaginatedResultDto<StaffZoneDto>> Handle(GetListStaffZoneIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.ShiftStart == null || x.ShiftStart == request.ShiftStart)
                && (request.ShiftEnd == null || x.ShiftEnd == request.ShiftEnd)
                && (request.Note == null || x.Note == request.Note)
                && (request.StaffId == null || x.StaffId == request.StaffId)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId)
                && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffZoneDto>(result, totalCount);
        }
    }
}

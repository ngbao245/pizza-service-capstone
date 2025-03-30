using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule
{
    public class GetListStaffZoneScheduleQueryHandler : IRequestHandler<GetListStaffZoneScheduleQuery, PaginatedResultDto<StaffZoneScheduleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public GetListStaffZoneScheduleQueryHandler(IMapper mapper, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _mapper = mapper;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<PaginatedResultDto<StaffZoneScheduleDto>> Handle(GetListStaffZoneScheduleQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneScheduleRepository.GetListAsNoTracking(
                x => (request.StaffName == null || x.StaffName.Contains(request.StaffName))
                && (request.ZoneName == null || x.ZoneName.Contains(request.ZoneName))
                && (request.WorkingDate == null || x.WorkingDate == request.WorkingDate)
                && (request.StaffId == null || x.StaffId == request.StaffId)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId)
                && (request.WorkingSlotId == null || x.WorkingSlotId == request.WorkingSlotId),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffZoneScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffZoneScheduleDto>(result, totalCount);
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter
{
    public class GetListStaffZoneScheduleIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffZoneScheduleIgnoreQueryFilterQuery, PaginatedResultDto<StaffZoneScheduleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public GetListStaffZoneScheduleIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _mapper = mapper;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<PaginatedResultDto<StaffZoneScheduleDto>> Handle(GetListStaffZoneScheduleIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            //var query = _StaffZoneScheduleRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
            //    .Where(
            //    x => (request.DayofWeek == null || x.DayofWeek == request.DayofWeek)
            //    && (request.ShiftStart == null || x.ShiftStart == request.ShiftStart)
            //    && (request.ShiftEnd == null || x.ShiftEnd == request.ShiftEnd)
            //    && (request.Note == null || x.Note == request.Note)
            //    && (request.StaffId == null || x.StaffId == request.StaffId)
            //    && (request.ZoneId == null || x.ZoneId == request.ZoneId)
            //    && (request.WorkingTimeId == null || x.WorkingTimeId == request.WorkingTimeId)

            //        && x.IsDeleted == request.IsDeleted);
            //var entities = await query
            //    .OrderBy(request.SortBy)
            //    .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            //var result = _mapper.Map<List<StaffZoneScheduleDto>>(entities);
            //var totalCount = await query.CountAsync();
            //return new PaginatedResultDto<StaffZoneScheduleDto>(result, totalCount);
            throw new NotImplementedException();
        }
    }
}

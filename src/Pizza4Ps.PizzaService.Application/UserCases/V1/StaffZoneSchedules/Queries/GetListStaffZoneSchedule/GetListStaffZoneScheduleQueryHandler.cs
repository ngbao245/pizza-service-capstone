using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

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
                x => (request.DayofWeek == null || x.DayofWeek == request.DayofWeek)
                && (request.ShiftStart == null || x.ShiftStart == request.ShiftStart)
                && (request.ShiftEnd == null || x.ShiftEnd == request.ShiftEnd)
                && (request.Note == null || x.Note == request.Note)
                && (request.StaffId == null || x.StaffId == request.StaffId)
                && (request.ZoneId == null || x.ZoneId == request.ZoneId)
                && (request.WorkingTimeId == null || x.WorkingTimeId == request.WorkingTimeId)

                ,
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffZoneScheduleErrorConstant.STAFFZONESCHEDULE_NOT_FOUND);
            var result = _mapper.Map<List<StaffZoneScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffZoneScheduleDto>(result, totalCount);
        }
    }
}

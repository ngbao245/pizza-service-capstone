using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListMonthly;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

public class GetMonthlyStaffZoneScheduleQueryHandler : IRequestHandler<GetMonthlyStaffZoneScheduleQuery, PaginatedResultDto<StaffZoneScheduleDto>>
{
    private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
    private readonly IStaffAbsenceRepository _staffAbsenceRepository;
    private readonly IMapper _mapper;

    public GetMonthlyStaffZoneScheduleQueryHandler(
        IStaffZoneScheduleRepository staffZoneScheduleRepository,
        IStaffAbsenceRepository staffAbsenceRepository,
        IMapper mapper)
    {
        _staffZoneScheduleRepository = staffZoneScheduleRepository;
        _staffAbsenceRepository = staffAbsenceRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResultDto<StaffZoneScheduleDto>> Handle(GetMonthlyStaffZoneScheduleQuery request, CancellationToken cancellationToken)
    {
        // Query danh sách ca làm trong khoảng thời gian
        var query = _staffZoneScheduleRepository.GetListAsNoTracking(
            x => x.StaffId == request.StaffId &&
                 x.WorkingDate >= request.FromDate &&
                 x.WorkingDate <= request.ToDate);

        // Lấy danh sách ca vắng mặt trong cùng khoảng thời gian
        var absenceList = await _staffAbsenceRepository.GetListAsNoTracking(
            x => x.StaffId == request.StaffId &&
                 x.AbsentDate >= request.FromDate &&
                 x.AbsentDate <= request.ToDate)
            .ToListAsync(cancellationToken);

        // Loại bỏ ca vắng mặt
        if (absenceList.Any())
        {
            query = query.Where(sch => !absenceList.Any(abs =>
                abs.AbsentDate == sch.WorkingDate && abs.WorkingSlotId == sch.WorkingSlotId));
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var paginatedList = await query
            .OrderByDescending(x => x.WorkingDate)
            .Skip(request.SkipCount)
            .Take(request.TakeCount)
            .ToListAsync(cancellationToken);
        var result = _mapper.Map<List<StaffZoneScheduleDto>>(paginatedList);
        return new PaginatedResultDto<StaffZoneScheduleDto>(result, totalCount);
    }
}

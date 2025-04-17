using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetCurrentWorkingSlot
{
    public class GetCurrentWorkingSlotQueryHandler : IRequestHandler<GetCurrentWorkingSlotQuery, WorkingSlotDto>
    {
        private readonly IWorkingSlotRepository _workingSlotRepository;
        private readonly IMapper _mapper;

        public GetCurrentWorkingSlotQueryHandler(
            IWorkingSlotRepository workingSlotRepository,
            IMapper mapper)
        {
            _workingSlotRepository = workingSlotRepository;
            _mapper = mapper;
        }

        public async Task<WorkingSlotDto> Handle(GetCurrentWorkingSlotQuery request, CancellationToken cancellationToken)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(7));
            var nowTime = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(7));
            var dayName = GetDayName(today);

            var query = _workingSlotRepository.GetListAsNoTracking(
                x => x.Day.Name == dayName
                && x.ShiftStart <= nowTime.ToTimeSpan()
                && nowTime.ToTimeSpan() < x.ShiftEnd,
                includeProperties: "Shift,Day");
            var result = await query.FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<WorkingSlotDto>(result);
        }

        private string GetDayName(DateOnly date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Thứ hai";
                case DayOfWeek.Tuesday: return "Thứ ba";
                case DayOfWeek.Wednesday: return "Thứ tư";
                case DayOfWeek.Thursday: return "Thứ năm";
                case DayOfWeek.Friday: return "Thứ sáu";
                case DayOfWeek.Saturday: return "Thứ bảy";
                case DayOfWeek.Sunday: return "Chủ nhật";
                default: throw new BusinessException(BussinessErrorConstants.DayErrorConstant.DAY_NOT_FOUND);
            }
        }
    }
}

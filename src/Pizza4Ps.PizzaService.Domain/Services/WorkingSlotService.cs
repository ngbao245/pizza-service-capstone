using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Constants;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkingSlotService : DomainService, IWorkingSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkingSlotRepository _workingSlotRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly IDayRepository _dayRepository;

        public WorkingSlotService(
            IUnitOfWork unitOfWork,
            IWorkingSlotRepository workingSlotRepository,
            IShiftRepository shiftRepository,
            IDayRepository dayRepository)
        {
            _unitOfWork = unitOfWork;
            _workingSlotRepository = workingSlotRepository;
            _shiftRepository = shiftRepository;
            _dayRepository = dayRepository;
        }

        public async Task<Guid> CreateAsync(TimeSpan shiftStart, TimeSpan shiftEnd, int capacity, Guid dayId, Guid shiftId)
        {
            var shift = await _shiftRepository.GetSingleByIdAsync(shiftId);
            if (shift == null) throw new BusinessException(BussinessErrorConstants.ShiftErrorConstant.SHIFT_NOT_FOUND);

            var day = await _dayRepository.GetSingleByIdAsync(dayId);
            if (day == null) throw new BusinessException(BussinessErrorConstants.DayErrorConstant.DAY_NOT_FOUND);

            var entity = new WorkingSlot(Guid.NewGuid(), shift.Name, day.Name, shiftStart, shiftEnd, capacity, dayId, shiftId);
            _workingSlotRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkingSlotService : DomainService, IWorkingSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkingSlotRepository _workingSlotRepository;

        public WorkingSlotService(IUnitOfWork unitOfWork, IWorkingSlotRepository workingSlotRepository)
        {
            _unitOfWork = unitOfWork;
            _workingSlotRepository = workingSlotRepository;
        }

        public async Task<Guid> CreateAsync(TimeSpan shiftStart, TimeSpan shiftEnd, int capacity, Guid dayId, Guid shiftId)
        {
            var entity = new WorkingSlot(Guid.NewGuid(), shiftStart, shiftEnd, capacity, dayId, shiftId);
            _workingSlotRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}
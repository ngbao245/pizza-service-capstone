using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Constants;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkingSlotRegisterService : DomainService, IWorkingSlotRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkingSlotRegisterRepository _workingSlotRegisterRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IWorkingSlotRepository _workingSlotRepository;

        public WorkingSlotRegisterService(
            IUnitOfWork unitOfWork,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository,
            IConfigRepository configRepository,
            IWorkingSlotRepository workingSlotRepository)
        {
            _unitOfWork = unitOfWork;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
            _configRepository = configRepository;
            _workingSlotRepository = workingSlotRepository;
        }

        public async Task<Guid> RegisterWorkingSlotAsync(DateTime workingDate, Guid staffId, Guid workingSlotId)
        {
            var existingRegistration = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingSlotId == workingSlotId);
            if (existingRegistration != null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.ALREADY_REGISTERED);
            }

            var maxSlotsConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.MAXIMUM_REGISTER_SLOT);
            var maxSlots = int.Parse(maxSlotsConfig.Value);

            var currentRegistrations = await _workingSlotRegisterRepository.CountAsync(x => x.WorkingSlotId == workingSlotId);

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);
            }

            var slotCapacity = workingSlot.Capacity;
            var status = WorkingSlotRegisterStatusEnum.Onhold;
            if (currentRegistrations < maxSlots && currentRegistrations < slotCapacity)
            {
                status = WorkingSlotRegisterStatusEnum.Approved;
            }

            var registration = new WorkingSlotRegister(workingDate, DateTime.Now, status, staffId, workingSlotId);
            _workingSlotRegisterRepository.Add(registration);

            await _unitOfWork.SaveChangeAsync();
            return registration.Id;
        }

        public async Task UpdateStatusToApprovedAsync(Guid id)
        {
            var entity = await _workingSlotRegisterRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            entity.setApproved();
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToRejectedAsync(Guid id)
        {
            var entity = await _workingSlotRegisterRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            entity.setRejected();
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class SwapWorkingSlotService : DomainService, ISwapWorkingSlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISwapWorkingSlotRepository _swapWorkingSlotRepository;
        private readonly IStaffZoneScheduleRepository _staffZoneScheduleRepository;
        private readonly IWorkingSlotRegisterRepository _workingSlotRegisterRepository;

        public SwapWorkingSlotService(
            IUnitOfWork unitOfWork,
            ISwapWorkingSlotRepository swapWorkingSlotRepository,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository)
        {
            _unitOfWork = unitOfWork;
            _swapWorkingSlotRepository = swapWorkingSlotRepository;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
        }

        public async Task<Guid> CreateAsync(Guid employeeFromId, Guid employeeToId, Guid workingSlotFromId, Guid workingSlotToId)
        {
            var workingSlotRegisterFrom = await _workingSlotRegisterRepository.GetSingleAsync(
              x => x.StaffId == employeeFromId && x.WorkingSlotId == workingSlotFromId && x.Status == WorkingSlotRegisterStatusEnum.Approved);
            var workingSlotRegisterTo = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == employeeToId && x.WorkingSlotId == workingSlotToId && x.Status == WorkingSlotRegisterStatusEnum.Approved);
            if (workingSlotRegisterFrom == null || workingSlotRegisterTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            }

            var swapWorkingSlot = new SwapWorkingSlot(Guid.NewGuid(), employeeFromId, employeeToId, workingSlotFromId, workingSlotToId);
            _swapWorkingSlotRepository.Add(swapWorkingSlot);
            await _unitOfWork.SaveChangeAsync();
            return swapWorkingSlot.Id;
        }

        public async Task UpdateStatusToPendingApproveAsync(Guid id)
        {
            var entity = await _swapWorkingSlotRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_NOT_FOUND);
            entity.setPendingApprove();
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToApprovedAsync(Guid id)
        {
            var entity = await _swapWorkingSlotRepository.GetSingleByIdAsync(id);
            if (entity == null) throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_NOT_FOUND);

            var workingSlotRegisterFrom = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeFromId && x.WorkingSlotId == entity.WorkingSlotFromId);
            var workingSlotRegisterTo = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeToId && x.WorkingSlotId == entity.WorkingSlotToId);
            if (workingSlotRegisterFrom == null || workingSlotRegisterTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            }

            //swap shifts
            var tempWorkingSlotId = workingSlotRegisterFrom.WorkingSlotId;
            workingSlotRegisterFrom.WorkingSlotId = workingSlotRegisterTo.WorkingSlotId;
            workingSlotRegisterTo.WorkingSlotId = tempWorkingSlotId;

            _workingSlotRegisterRepository.Update(workingSlotRegisterFrom);
            _workingSlotRegisterRepository.Update(workingSlotRegisterTo);

            //swap zone
            var staffZoneScheduleFrom = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeFromId && x.WorkingSlotId == entity.WorkingSlotFromId);
            var staffZoneScheduleTo = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeToId && x.WorkingSlotId == entity.WorkingSlotToId);

            if (staffZoneScheduleFrom != null && staffZoneScheduleTo != null)
            {
                var tempZoneId = staffZoneScheduleFrom.ZoneId;
                staffZoneScheduleFrom.ZoneId = staffZoneScheduleTo.ZoneId;
                staffZoneScheduleTo.ZoneId = tempZoneId;

                _staffZoneScheduleRepository.Update(staffZoneScheduleFrom);
                _staffZoneScheduleRepository.Update(staffZoneScheduleTo);
            }
            entity.setApproved();
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateStatusToRejectedAsync(Guid id)
        {
            var entity = await _swapWorkingSlotRepository.GetSingleByIdAsync(id);
            if (entity.Status != SwapWorkingSlotStatusEnum.PendingStaffAgree &&
                entity.Status != SwapWorkingSlotStatusEnum.PendingManagerApprove)
            {
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_INVALID_STATE);
            }
            entity.setRejected();
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

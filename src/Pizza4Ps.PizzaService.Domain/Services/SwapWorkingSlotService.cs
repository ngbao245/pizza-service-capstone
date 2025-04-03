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
        private readonly IStaffRepository _staffRepository;
        private readonly IConfigRepository _configRepository;

        public SwapWorkingSlotService(
            IUnitOfWork unitOfWork,
            ISwapWorkingSlotRepository swapWorkingSlotRepository,
            IStaffZoneScheduleRepository staffZoneScheduleRepository,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository,
            IStaffRepository staffRepository,
            IConfigRepository configRepository)
        {
            _unitOfWork = unitOfWork;
            _swapWorkingSlotRepository = swapWorkingSlotRepository;
            _staffZoneScheduleRepository = staffZoneScheduleRepository;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
            _staffRepository = staffRepository;
            _configRepository = configRepository;
        }

        public async Task<Guid> CreateAsync(DateOnly workingDateFrom, Guid employeeFromId, Guid workingSlotFromId,
                                            DateOnly workingDateTo, Guid employeeToId, Guid workingSlotToId)
        {
            var employeeFrom = await _staffRepository.GetSingleByIdAsync(employeeFromId);
            var employeeTo = await _staffRepository.GetSingleByIdAsync(employeeToId);
            if (employeeFrom == null || employeeTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);
            }

            var workingSlotRegisterFrom = await _workingSlotRegisterRepository.GetSingleAsync(
              x => x.StaffId == employeeFromId
              && x.WorkingDate == workingDateFrom
              && x.WorkingSlotId == workingSlotFromId
              && x.Status == WorkingSlotRegisterStatusEnum.Approved);

            var workingSlotRegisterTo = await _workingSlotRegisterRepository.GetSingleAsync(
              x => x.StaffId == employeeToId
              && x.WorkingDate == workingDateTo
              && x.WorkingSlotId == workingSlotToId
              && x.Status == WorkingSlotRegisterStatusEnum.Approved);

            if (workingSlotRegisterFrom == null || workingSlotRegisterTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            }

            if (workingDateFrom == workingDateTo && workingSlotFromId == workingSlotToId)
            {
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_INVALID_WORKING_DATE);
            }

            var cutoffConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.SWAP_WORKING_SLOT_CUTOFF_DAY);
            int cutoffDays = int.Parse(cutoffConfig.Value);

            var today = DateOnly.FromDateTime(DateTime.Today);
            var earliestWorkingDate = workingDateFrom < workingDateTo ? workingDateFrom : workingDateTo;
            var startOfWeek = earliestWorkingDate.AddDays(-(int)earliestWorkingDate.DayOfWeek + (int)DayOfWeek.Monday);
            if (earliestWorkingDate < today.AddDays(cutoffDays) || earliestWorkingDate < startOfWeek)
            {
                throw new BusinessException($"Đơn đổi ca phải được tạo trước ít nhất {cutoffDays} ngày và trước thứ hai đầu tuần");
            }

            var swapWorkingSlot = new SwapWorkingSlot(
                id: Guid.NewGuid(),
                workingDateFrom: workingDateFrom,
                employeeFromName: employeeFrom.FullName,
                employeeFromId: employeeFromId,
                workingSlotFromId: workingSlotFromId,
                workingDateTo: workingDateTo,
                employeeToName: employeeTo.FullName,
                employeeToId: employeeToId,
                workingSlotToId: workingSlotToId
            );
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
                x => x.StaffId == entity.EmployeeFromId
                     && x.WorkingSlotId == entity.WorkingSlotFromId
                     && x.WorkingDate == entity.WorkingDateFrom);
            var workingSlotRegisterTo = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeToId
                     && x.WorkingSlotId == entity.WorkingSlotToId
                     && x.WorkingDate == entity.WorkingDateTo);

            if (workingSlotRegisterFrom == null || workingSlotRegisterTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.WORKING_SLOT_REGISTER_NOT_FOUND);
            }

            //swap shift and workingDate
            var tempWorkingSlotId = workingSlotRegisterFrom.WorkingSlotId;
            var tempWorkingDate = workingSlotRegisterFrom.WorkingDate;

            workingSlotRegisterFrom.WorkingSlotId = workingSlotRegisterTo.WorkingSlotId;
            workingSlotRegisterFrom.WorkingDate = workingSlotRegisterTo.WorkingDate;

            workingSlotRegisterTo.WorkingSlotId = tempWorkingSlotId;
            workingSlotRegisterTo.WorkingDate = tempWorkingDate;

            _workingSlotRegisterRepository.Update(workingSlotRegisterFrom);
            _workingSlotRegisterRepository.Update(workingSlotRegisterTo);

            //swap zone
            var staffZoneScheduleFrom = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeFromId
                     && x.WorkingSlotId == entity.WorkingSlotFromId
                     && x.WorkingDate == entity.WorkingDateFrom);
            var staffZoneScheduleTo = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeToId
                     && x.WorkingSlotId == entity.WorkingSlotToId
                     && x.WorkingDate == entity.WorkingDateTo);

            if (staffZoneScheduleFrom != null && staffZoneScheduleTo != null)
            {
                var tempZoneId = staffZoneScheduleFrom.ZoneId;
                staffZoneScheduleFrom.ZoneId = staffZoneScheduleTo.ZoneId;
                staffZoneScheduleTo.ZoneId = tempZoneId;

                staffZoneScheduleFrom.WorkingDate = workingSlotRegisterFrom.WorkingDate;
                staffZoneScheduleTo.WorkingDate = workingSlotRegisterTo.WorkingDate;

                _staffZoneScheduleRepository.Update(staffZoneScheduleFrom);
                _staffZoneScheduleRepository.Update(staffZoneScheduleTo);
            }

            var tempWorkingDateFrom = entity.WorkingDateFrom;
            entity.WorkingDateFrom = entity.WorkingDateTo;
            entity.WorkingDateTo = tempWorkingDateFrom;

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

using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            // Kiểm tra xem đã có đơn đổi ca tồn tại chưa
            var existingSwapRequest = await _swapWorkingSlotRepository.GetSingleAsync(
                    x => (x.EmployeeFromId == employeeFromId && x.EmployeeToId == employeeToId
                    && x.WorkingDateFrom == workingDateFrom && x.WorkingDateTo == workingDateTo
                    && x.WorkingSlotFromId == workingSlotFromId && x.WorkingSlotToId == workingSlotToId)
                    || (x.EmployeeFromId == employeeToId && x.EmployeeToId == employeeFromId
                    && x.WorkingDateFrom == workingDateTo && x.WorkingDateTo == workingDateFrom
                    && x.WorkingSlotFromId == workingSlotToId && x.WorkingSlotToId == workingSlotFromId));

            if (existingSwapRequest != null)
            {
                throw new BusinessException("Đã tồn tại đơn đổi ca cho cặp nhân viên và ca làm này.");
            }

            // Kiểm tra nhân viên có tồn tại hay không
            var employeeFrom = await _staffRepository.GetSingleByIdAsync(employeeFromId);
            var employeeTo = await _staffRepository.GetSingleByIdAsync(employeeToId);
            if (employeeFrom == null || employeeTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);
            }

            // Kiểm tra trạng thái nhân viên phải là partTime không
            if (employeeFrom.Status != StaffStatusEnum.PartTime || employeeTo.Status != StaffStatusEnum.PartTime)
            {
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_INVALID_STAFF_STATUS);
            }

            var hasStaffZoneScheduleFrom = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == employeeFromId
                && x.WorkingDate == workingDateFrom
                && x.WorkingSlotId == workingSlotFromId);

            var hasStaffZoneScheduleTo = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == employeeToId
                && x.WorkingDate == workingDateTo
                && x.WorkingSlotId == workingSlotToId);

            if (hasStaffZoneScheduleFrom == null || hasStaffZoneScheduleTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_INVALID_REQUEST);
            }

            // Kiểm tra đơn đổi ca đã duyệt
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

            // Kiểm tra có trùng ngày trung ca làm việc không
            if (workingDateFrom == workingDateTo && workingSlotFromId == workingSlotToId)
            {
                throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_INVALID_WORKING_DATE);
            }

            // Kiểm tra thời gian tạo đơn đổi ca
            var cutoffConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.SWAP_WORKING_SLOT_CUTOFF_DAY);
            int cutoffDays = int.Parse(cutoffConfig.Value);

            var utcNow = DateTime.UtcNow;
            var vietnamTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "SE Asia Standard Time");
            var today = DateOnly.FromDateTime(vietnamTime);

            var earliestWorkingDate = workingDateFrom < workingDateTo ? workingDateFrom : workingDateTo;
            var startOfWeek = earliestWorkingDate.AddDays(-(int)earliestWorkingDate.DayOfWeek + (int)DayOfWeek.Monday);
            var deadlineForRequest = startOfWeek.AddDays(-cutoffDays);
            if (today > deadlineForRequest)
            {
                throw new BusinessException($"Đơn đổi ca phải được tạo trước ít nhất {cutoffDays} ngày so với thứ hai của tuần có ngày làm việc sớm nhất ({startOfWeek}). Hạn chót tạo đơn là {deadlineForRequest}.");
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

            var staffZoneScheduleFrom = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeFromId
                     && x.WorkingSlotId == entity.WorkingSlotFromId
                     && x.WorkingDate == entity.WorkingDateFrom);
            var staffZoneScheduleTo = await _staffZoneScheduleRepository.GetSingleAsync(
                x => x.StaffId == entity.EmployeeToId
                     && x.WorkingSlotId == entity.WorkingSlotToId
                     && x.WorkingDate == entity.WorkingDateTo);

            if (staffZoneScheduleFrom == null || staffZoneScheduleTo == null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffZoneScheduleErrorConstant.STAFF_ZONE_SCHEDULE_NOT_FOUND);
            }

            var tempZoneId = staffZoneScheduleFrom.ZoneId;
            var tempSlotId = staffZoneScheduleFrom.WorkingSlotId;
            var tempDate = staffZoneScheduleFrom.WorkingDate;
            var tempStaffId = staffZoneScheduleFrom.StaffId;

            staffZoneScheduleFrom.ZoneId = staffZoneScheduleTo.ZoneId;
            staffZoneScheduleFrom.WorkingSlotId = staffZoneScheduleTo.WorkingSlotId;
            staffZoneScheduleFrom.WorkingDate = staffZoneScheduleTo.WorkingDate;
            staffZoneScheduleFrom.StaffId = staffZoneScheduleTo.StaffId;

            staffZoneScheduleTo.ZoneId = tempZoneId;
            staffZoneScheduleTo.WorkingSlotId = tempSlotId;
            staffZoneScheduleTo.WorkingDate = tempDate;
            staffZoneScheduleTo.StaffId = tempStaffId;

            _staffZoneScheduleRepository.Update(staffZoneScheduleFrom);
            _staffZoneScheduleRepository.Update(staffZoneScheduleTo);

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

        public async Task DeleteAsync(List<Guid> ids, bool IsHardDeleted = false)
        {
            var entities = await _swapWorkingSlotRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new BusinessException(BussinessErrorConstants.SwapWorkingSlotErrorConstant.SWAP_WORKING_SLOT_NOT_FOUND);
            foreach (var entity in entities)
            {
                if (IsHardDeleted)
                {
                    _swapWorkingSlotRepository.HardDelete(entity);
                }
                else
                {
                    _swapWorkingSlotRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

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
        private readonly IStaffRepository _staffRepository;

        public WorkingSlotRegisterService(
            IUnitOfWork unitOfWork,
            IWorkingSlotRegisterRepository workingSlotRegisterRepository,
            IConfigRepository configRepository,
            IWorkingSlotRepository workingSlotRepository,
            IStaffRepository staffRepository)
        {
            _unitOfWork = unitOfWork;
            _workingSlotRegisterRepository = workingSlotRegisterRepository;
            _configRepository = configRepository;
            _workingSlotRepository = workingSlotRepository;
            _staffRepository = staffRepository;
        }

        public async Task<Guid> RegisterWorkingSlotAsync(DateTime workingDate, Guid staffId, Guid workingSlotId)
        {

            var staff = await _staffRepository.GetSingleByIdAsync(staffId);
            if (staff == null) throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);

            var existingRegistration = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingSlotId == workingSlotId);
            if (existingRegistration != null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.ALREADY_REGISTERED);
            }

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);
            }

            var cutoffConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY);
            int cutoffDays = int.Parse(cutoffConfig.Value);

            DateTime startOfWeek = workingDate.Date.AddDays(-(int)workingDate.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime cutoffDate = startOfWeek.AddDays(-cutoffDays);
            if (DateTime.UtcNow.Date > cutoffDate)
            {
                throw new BusinessException($"Hạn đăng ký đã kết thúc vào ngày {cutoffDate:yyyy-MM-dd}. Bạn phải đăng ký trước {cutoffDays} ngày.");
            }

            var expectedDayOfWeek = GetDayOfWeekFromDayName(workingSlot.DayName);
            if (workingDate.DayOfWeek != expectedDayOfWeek)
            {
                throw new BusinessException($"Ngày {workingDate:yyyy-MM-dd} không hợp lệ cho ca {workingSlot.ShiftName} (chỉ áp dụng cho {workingSlot.DayName}).");
            }

            var maxSlotsConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.MAXIMUM_REGISTER_SLOT);
            var maxSlots = int.Parse(maxSlotsConfig.Value);

            var currentRegistrations = await _workingSlotRegisterRepository.CountAsync(x => x.WorkingSlotId == workingSlotId);
            var slotCapacity = workingSlot.Capacity;

            var status = WorkingSlotRegisterStatusEnum.Onhold;
            if (currentRegistrations < maxSlots && currentRegistrations < slotCapacity)
            {
                status = WorkingSlotRegisterStatusEnum.Approved;
            }

            var registration = new WorkingSlotRegister(Guid.NewGuid(), staff.FullName, workingDate, DateTime.Now, status, staffId, workingSlotId);
            _workingSlotRegisterRepository.Add(registration);

            await _unitOfWork.SaveChangeAsync();
            return registration.Id;
        }

        private DayOfWeek GetDayOfWeekFromDayName(string dayName)
        {
            return dayName.ToLower() switch
            {
                "monday" => DayOfWeek.Monday,
                "tuesday" => DayOfWeek.Tuesday,
                "wednesday" => DayOfWeek.Wednesday,
                "thursday" => DayOfWeek.Thursday,
                "friday" => DayOfWeek.Friday,
                "saturday" => DayOfWeek.Saturday,
                "sunday" => DayOfWeek.Sunday,
                _ => throw new BusinessException(BussinessErrorConstants.DayErrorConstant.INVALID_DAY_OF_WEEK)
            };
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

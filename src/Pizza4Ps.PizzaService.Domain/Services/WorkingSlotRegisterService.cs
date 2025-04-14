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

        public async Task<Guid> RegisterWorkingSlotAsync(DateOnly workingDate, Guid staffId, Guid workingSlotId)
        {
            var staff = await _staffRepository.GetSingleByIdAsync(staffId);
            if (staff == null) throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);

            if (staff.Status != StaffStatusEnum.PartTime)
            {
                throw new BusinessException(BussinessErrorConstants.WorkingSlotRegisterErrorConstant.INVALID_STAFF_STATUS);
            }

            var existingRegistration = await _workingSlotRegisterRepository.GetSingleAsync(
                x => x.StaffId == staffId && x.WorkingSlotId == workingSlotId && x.WorkingDate == workingDate);
            if (existingRegistration != null) throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.ALREADY_REGISTERED);

            var workingSlot = await _workingSlotRepository.GetSingleByIdAsync(workingSlotId);
            if (workingSlot == null) throw new BusinessException(BussinessErrorConstants.WorkingSlotErrorConstant.WORKING_SLOT_NOT_FOUND);

            var cutoffConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.REGISTRATION_CUTOFF_DAY);
            int cutoffDays = int.Parse(cutoffConfig.Value);

            var utcNow = DateTime.UtcNow;
            var vietnamTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcNow, "SE Asia Standard Time");

            DateOnly startOfWeek = workingDate.AddDays(-(int)workingDate.DayOfWeek + (int)DayOfWeek.Monday);
            DateOnly cutoffDate = startOfWeek.AddDays(-cutoffDays);
            if (vietnamTime > cutoffDate.ToDateTime(TimeOnly.MinValue))
            {
                throw new BusinessException($"Hạn đăng ký đã kết thúc vào ngày {cutoffDate:yyyy-MM-dd}, bạn phải đăng ký trước ngày {cutoffDays}");
            }

            var expectedDayOfWeek = GetDayOfWeekFromDayName(workingSlot.DayName);
            if (workingDate.DayOfWeek != expectedDayOfWeek)
            {
                throw new BusinessException($"Ngày {workingDate:yyyy-MM-dd} không hợp lệ cho ca {workingSlot.ShiftName} vì ca này chỉ áp dụng cho {workingSlot.DayName.ToLower()}");
            }

            var maxRegisterDaysConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.REGISTRATION_WEEK_LIMIT);
            int maxRegisterDays = int.Parse(maxRegisterDaysConfig.Value) * 7;

            DateOnly startOfNextWeek = DateOnly.FromDateTime(vietnamTime.Date)
                .AddDays(7 - (int)DateTime.UtcNow.DayOfWeek + (int)DayOfWeek.Monday);
            DateOnly maxRegisterDate = startOfNextWeek.AddDays(maxRegisterDays - 1);
            if (workingDate > maxRegisterDate)
            {
                throw new BusinessException($"Bạn chỉ có thể đăng ký trước tối đa {maxRegisterDays} ngày từ ngày {startOfNextWeek:yyyy-MM-dd}. Hạn đăng ký cho ngày {workingDate:yyyy-MM-dd} đã vượt quá giới hạn.");
            }

            var registeredSlotsInWeek = await _workingSlotRegisterRepository.CountAsync(
                x => x.StaffId == staffId && x.WorkingDate >= startOfWeek && x.WorkingDate <= startOfWeek.AddDays(6));

            var maxRegisterPerStaffConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.MAXIMUM_REGISTER_PER_STAFF);
            int maxRegisterPerStaff = int.Parse(maxRegisterPerStaffConfig.Value);

            var status = (registeredSlotsInWeek >= maxRegisterPerStaff)
                ? WorkingSlotRegisterStatusEnum.Onhold
                : WorkingSlotRegisterStatusEnum.Approved;

            var maxSlotsConfig = await _configRepository.GetSingleAsync(
                x => x.ConfigType == ConfigType.MAXIMUM_REGISTER_SLOT);
            var maxSlots = int.Parse(maxSlotsConfig.Value);

            var currentRegistrations = await _workingSlotRegisterRepository.CountAsync(
                x => x.WorkingSlotId == workingSlotId && x.WorkingDate == workingDate);

            if (currentRegistrations >= maxSlots)
            {
                status = WorkingSlotRegisterStatusEnum.Onhold;
            }

            var workingSlotRegister = new WorkingSlotRegister(Guid.NewGuid(), staff.FullName, workingDate, DateTimeOffset.Now, status, staffId, workingSlotId);
            _workingSlotRegisterRepository.Add(workingSlotRegister);
            await _unitOfWork.SaveChangeAsync();
            return workingSlotRegister.Id;
        }

        private DayOfWeek GetDayOfWeekFromDayName(string dayName)
        {
            return dayName.ToLower() switch
            {
                "thứ hai" => DayOfWeek.Monday,
                "thứ ba" => DayOfWeek.Tuesday,
                "thứ tư" => DayOfWeek.Wednesday,
                "thứ năm" => DayOfWeek.Thursday,
                "thứ sáu" => DayOfWeek.Friday,
                "thứ bảy" => DayOfWeek.Saturday,
                "chủ nhật" => DayOfWeek.Sunday,
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

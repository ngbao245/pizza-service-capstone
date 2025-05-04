using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkshopService : DomainService, IWorkshopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IBackgroundJobService _backgroundJobService;
        private readonly IWorkshopFoodDetailRepository _workshopFoodDetailRepository;

        public WorkshopService(IWorkshopRepository workshopRepository,
            IWorkshopFoodDetailRepository workshopFoodDetailRepository,
            IUnitOfWork unitOfWork, IBackgroundJobService backgroundJobService)
        {
            _unitOfWork = unitOfWork;
            _workshopRepository = workshopRepository;
            _backgroundJobService = backgroundJobService;
            _workshopFoodDetailRepository = workshopFoodDetailRepository;
        }
        public async Task<Guid> CreateAsync(Workshop workshop, List<WorkshopFoodDetail> workshopFoodDetails)
        {
            _workshopRepository.Add(workshop);
            _workshopFoodDetailRepository.AddRange(workshopFoodDetails);
            await _unitOfWork.SaveChangeAsync();
            // Tính delay từ thời điểm hiện tại đến thời gian đăng ký
            TimeSpan openRegisterDelay = workshop.StartRegisterDate - DateTime.Now;
            if (openRegisterDelay < TimeSpan.Zero)
            {
                openRegisterDelay = TimeSpan.Zero;
            }
            TimeSpan closeRegisterDelay = workshop.EndRegisterDate - DateTime.Now;
            if (closeRegisterDelay < TimeSpan.Zero)
            {
                closeRegisterDelay = TimeSpan.Zero;
            }
            TimeSpan openDelay = workshop.WorkshopDate - DateTime.Now;
            if (openDelay < TimeSpan.Zero)
            {
                openDelay = TimeSpan.Zero;
            }

            // Lập lịch job mở đăng ký
            string openRegisterJobId = _backgroundJobService.ScheduleJob<WorkshopService>(
                service => service.StartRegisterWorkshopSync(workshop.Id),
                openRegisterDelay);

            // Lập lịch job đóng đăng ký
            string closeRegisterJobId = _backgroundJobService.ScheduleJob<WorkshopService>(
                service => service.StopRegisterWorkshopSync(workshop.Id),
                closeRegisterDelay);

            // Lập lịch job mở workshop
            string OpenWorkshopJobId = _backgroundJobService.ScheduleJob<WorkshopService>(
                service => service.OpenWorkshopSync(workshop.Id),
                openDelay);

            // Cập nhật JobId vào Workshop
            workshop.SetOpenRegisterJobId(openRegisterJobId);
            workshop.SetCloseRegisterJobId(closeRegisterJobId);
            workshop.SetOpeningWorkshopJobId(OpenWorkshopJobId);

            await _unitOfWork.SaveChangeAsync();
            return workshop.Id;
        }

        public async Task StartRegisterWorkshop(Guid workshopId)
        {
            var workshop = await _workshopRepository.GetSingleAsync(x => x.Id == workshopId);
            if (workshop != null)
            {
                workshop.StartRegister();
                _workshopRepository.Update(workshop);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task CloseRegisterWorkshop(Guid workshopId)
        {
            var workshop = await _workshopRepository.GetSingleAsync(x => x.Id == workshopId);
            if (workshop != null)
            {
                workshop.StopRegister();
                _workshopRepository.Update(workshop);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task OpenWorkshop(Guid workshopId)
        {
            var workshop = await _workshopRepository.GetSingleAsync(x => x.Id == workshopId);
            if (workshop != null)
            {
                workshop.OpenWorkshop();
                _workshopRepository.Update(workshop);
                await _unitOfWork.SaveChangeAsync();
            }
        }
        // Các wrapper đồng bộ để sử dụng với Hangfire
        public void StartRegisterWorkshopSync(Guid workshopId)
        {
            StartRegisterWorkshop(workshopId).GetAwaiter().GetResult();
        }

        public void StopRegisterWorkshopSync(Guid workshopId)
        {
            CloseRegisterWorkshop(workshopId).GetAwaiter().GetResult();
        }

        public void OpenWorkshopSync(Guid workshopId)
        {
            OpenWorkshop(workshopId).GetAwaiter().GetResult();
        }

        public async Task ReOpenToRegisterWorkshop(Guid workshopId, DateTime newEndRegisterDate)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(workshopId);
            if (workshop != null)
            {
                if (workshop.WorkshopStatus != Domain.Enums.WorkshopStatus.ClosedRegister)
                {
                    throw new BusinessException("Workshop không ở trạng thái đã đóng đăng ký");
                }
                workshop.ReOpenToRegister(newEndRegisterDate);
                _workshopRepository.Update(workshop);
                await _unitOfWork.SaveChangeAsync();
            }
            throw new BusinessException("Workshop không tồn tại");
        }
        public async Task ForceOpenWorkshop(Guid workshopId)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(workshopId);
            if (workshop != null)
            {
                if (workshop.OpeningWorkshopJobId != null)
                {
                    _backgroundJobService.RemoveRecurringJob(workshop.OpeningWorkshopJobId);
                    workshop.SetOpeningWorkshopJobId(null);
                }
                workshop.OpenWorkshop();
                _workshopRepository.Update(workshop);
                await _unitOfWork.SaveChangeAsync();
            }
            throw new BusinessException("Workshop không tồn tại");
        }
    }
}

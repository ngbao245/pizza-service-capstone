using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.BackgroundJobs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
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
            TimeSpan openDelay = workshop.StartRegisterDate - DateTime.Now;
            if (openDelay < TimeSpan.Zero)
            {
                openDelay = TimeSpan.Zero;
            }
            TimeSpan closeDelay = workshop.EndRegisterDate - DateTime.Now;
            if (closeDelay < TimeSpan.Zero)
            {
                closeDelay = TimeSpan.Zero;
            }

            // Lập lịch job mở đăng ký
            string openJobId = _backgroundJobService.ScheduleJob<WorkshopService>(
                service => service.StartRegisterWorkshopSync(workshop.Id),
                openDelay);

            // Lập lịch job đóng đăng ký
            string closeJobId = _backgroundJobService.ScheduleJob<WorkshopService>(
                service => service.StopRegisterWorkshopSync(workshop.Id),
                closeDelay);

            // Cập nhật JobId vào Workshop
            workshop.SetOpenRegisterJobId(openJobId);
            workshop.SetCloseRegisterJobId(closeJobId);
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
        // Các wrapper đồng bộ để sử dụng với Hangfire
        public void StartRegisterWorkshopSync(Guid workshopId)
        {
            StartRegisterWorkshop(workshopId).GetAwaiter().GetResult();
        }

        public void StopRegisterWorkshopSync(Guid workshopId)
        {
            CloseRegisterWorkshop(workshopId).GetAwaiter().GetResult();
        }
    }
}

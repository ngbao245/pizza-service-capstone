using Pizza4Ps.PizzaService.Domain.Abstractions;
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
        private readonly IWorkshopFoodDetailRepository _workshopFoodDetailRepository;

        public WorkshopService(IWorkshopRepository workshopRepository,
            IWorkshopFoodDetailRepository workshopFoodDetailRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _workshopRepository = workshopRepository;
            _workshopFoodDetailRepository = workshopFoodDetailRepository;
        }
        public async Task<Guid> CreateAsync(Workshop workshop, List<WorkshopFoodDetail> workshopFoodDetails)
        {
            _workshopRepository.Add(workshop);
            _workshopFoodDetailRepository.AddRange(workshopFoodDetails);
            await _unitOfWork.SaveChangeAsync();
            return workshop.Id;
        }
    }
}

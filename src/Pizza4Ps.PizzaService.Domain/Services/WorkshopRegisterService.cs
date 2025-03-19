using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkshopRegisterService : DomainService, IWorkshopRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopPizzaRegisterRepository _workshopPizzaRegisterRepository;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        private readonly IWorkshopPizzaRegisterDetailRepository _workshopPizzaRegisterDetailRepository;

        public WorkshopRegisterService(IWorkshopRegisterRepository workshopRegisterRepository,
            IWorkshopPizzaRegisterRepository workshopPizzaRegisterRepository,
            IWorkshopPizzaRegisterDetailRepository workshopPizzaRegisterDetailRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _workshopPizzaRegisterRepository = workshopPizzaRegisterRepository;
            _workshopRegisterRepository = workshopRegisterRepository;
            _workshopPizzaRegisterDetailRepository = workshopPizzaRegisterDetailRepository;
        }
        public async Task<Guid> RegisterAsync(WorkshopRegister workshopRegister, List<WorkshopPizzaRegister> workshopPizzaRegisters, List<WorkshopPizzaRegisterDetail> workshopPizzaRegisterDetails)
        {
            _workshopRegisterRepository.Add(workshopRegister);
            _workshopPizzaRegisterRepository.AddRange(workshopPizzaRegisters);
            _workshopPizzaRegisterDetailRepository.AddRange(workshopPizzaRegisterDetails);
            await _unitOfWork.SaveChangeAsync();
            return workshopRegister.Id;
        }
    }
}

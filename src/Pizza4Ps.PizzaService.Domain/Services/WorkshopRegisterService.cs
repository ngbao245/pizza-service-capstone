using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class WorkshopRegisterService : DomainService, IWorkshopRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IWorkshopPizzaRegisterRepository _workshopPizzaRegisterRepository;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        private readonly IWorkshopPizzaRegisterDetailRepository _workshopPizzaRegisterDetailRepository;

        public WorkshopRegisterService(IWorkshopRegisterRepository workshopRegisterRepository,
            IWorkshopPizzaRegisterRepository workshopPizzaRegisterRepository,
            IWorkshopPizzaRegisterDetailRepository workshopPizzaRegisterDetailRepository,
            IUnitOfWork unitOfWork, IWorkshopRepository workshopRepository)
        {
            _unitOfWork = unitOfWork;
            _workshopRepository = workshopRepository;
            _workshopPizzaRegisterRepository = workshopPizzaRegisterRepository;
            _workshopRegisterRepository = workshopRegisterRepository;
            _workshopPizzaRegisterDetailRepository = workshopPizzaRegisterDetailRepository;
        }
        public async Task<Guid> RegisterAsync(WorkshopRegister workshopRegister, List<WorkshopPizzaRegister> workshopPizzaRegisters, List<WorkshopPizzaRegisterDetail> workshopPizzaRegisterDetails)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(workshopRegister.WorkshopId);
            if (workshop == null)
            {
                throw new BusinessException("Workshop is not found");
            }
            workshop.AddWorkshopRegister();
            if (workshopRegister.TotalParticipant > workshop.MaxParticipantPerRegister)
            {
                throw new BusinessException($"You cannot register over {workshop.MaxParticipantPerRegister} participants");
            }
            _workshopRepository.Update(workshop);
            _workshopRegisterRepository.Add(workshopRegister);
            _workshopPizzaRegisterRepository.AddRange(workshopPizzaRegisters);
            _workshopPizzaRegisterDetailRepository.AddRange(workshopPizzaRegisterDetails);
            await _unitOfWork.SaveChangeAsync();
            return workshopRegister.Id;
        }
    }
}

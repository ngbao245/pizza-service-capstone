using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CancelWorkshopRegister
{
    public class CancelWorkshopRegisterCommandHandler : IRequestHandler<CancelWorkshopRegisterCommand>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        public CancelWorkshopRegisterCommandHandler(IUnitOfWork unitOfWork,
            IWorkshopRegisterRepository workshopRegisterRepository,
            IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
            _unitOfWork = unitOfWork;
            _workshopRegisterRepository = workshopRegisterRepository;
        }
        public async Task Handle(CancelWorkshopRegisterCommand request, CancellationToken cancellationToken)
        {
            var workshopRegister = await _workshopRegisterRepository.GetSingleByIdAsync(request.WorkshopRegisterId!.Value);
            if (workshopRegister == null)
            {
                throw new Exception("Workshop register not found");
            }
            workshopRegister.Cancel(request.Reason);
            var workshop = await _workshopRepository.GetSingleAsync(x => x.Id == workshopRegister.WorkshopId);
            if (workshop == null)
            {
                throw new Exception("Workshop not found");
            }
            workshop.totalRegisteredParticipant = workshop.totalRegisteredParticipant - 1;
            _workshopRegisterRepository.Update(workshopRegister);
            _workshopRepository.Update(workshop);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.UpdateWorkshop
{
    public class UpdateWorkshopCommandHandler : IRequestHandler<UpdateWorkshopCommand>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateWorkshopCommandHandler(IWorkshopRepository workshopRepository, IUnitOfWork unitOfWork)
        {
            _workshopRepository = workshopRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(request.Id!.Value);
            if (workshop == null)
            {
                throw new Exception($"Workshop with ID {request.Id} not found.");
            }
            workshop.Name = request.Name;
            workshop.Header = request.Header;
            workshop.Description = request.Description;
            workshop.Location = request.Location;
            workshop.Organizer = request.Organizer;
            workshop.HotLineContact = request.HotLineContact;
            workshop.MaxRegister = request.MaxRegister;
            workshop.MaxPizzaPerRegister = request.MaxPizzaPerRegister;
            workshop.MaxParticipantPerRegister = request.MaxParticipantPerRegister;
            _workshopRepository.Update(workshop);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}

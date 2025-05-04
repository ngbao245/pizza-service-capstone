using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CloseWorkshop
{
    public class CloseWorkshopCommandHandler : IRequestHandler<CloseWorkshopCommand>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CloseWorkshopCommandHandler(IWorkshopRepository workshopRepository, IUnitOfWork unitOfWork)
        {
            _workshopRepository = workshopRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CloseWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(request.Id!.Value);
            if (workshop == null)
            {
                throw new NotFoundException("Workshop not found");
            }
            workshop.CloseWorkshop();
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}

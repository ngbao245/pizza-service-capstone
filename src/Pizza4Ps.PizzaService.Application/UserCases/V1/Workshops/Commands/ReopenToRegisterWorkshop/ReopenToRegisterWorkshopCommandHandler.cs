using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.ReopenToRegisterWorkshop
{
    public class ReopenToRegisterWorkshopCommandHandler : IRequestHandler<ReopenToRegisterWorkshopCommand>
    {
        private readonly IWorkshopService _workshopService;

        public ReopenToRegisterWorkshopCommandHandler(
            IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }
        public async Task Handle(ReopenToRegisterWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshop = await _workshopRepository.GetSingleByIdAsync(request.WorkshopId);
            if (workshop == null)
            {
                throw new NotFoundException($"Workshop with id {request.WorkshopId} not found.");
            }
            if (workshop.WorkshopStatus != Domain.Enums.WorkshopStatus.ClosedRegister)
            {
                throw new BusinessException("Workshop is not in a closed state.");
            }
            workshop.ReOpenToRegister(request.NewEndRegisterDate);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
        }
    }
}

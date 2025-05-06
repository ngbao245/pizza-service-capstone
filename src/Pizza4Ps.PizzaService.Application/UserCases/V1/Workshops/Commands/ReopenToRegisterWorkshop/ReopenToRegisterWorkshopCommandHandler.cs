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
            await _workshopService.ReOpenToRegisterWorkshop(request.WorkshopId!.Value, request.NewEndRegisterDate);
        }
    }
}

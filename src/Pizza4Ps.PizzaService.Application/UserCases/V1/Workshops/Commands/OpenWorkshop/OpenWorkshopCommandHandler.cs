using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.OpenWorkshop
{
    public class OpenWorkshopCommandHandler : IRequestHandler<OpenWorkshopCommand>
    {
        private readonly IWorkshopService _workshopService;

        public OpenWorkshopCommandHandler(
            IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }
        public async Task Handle(OpenWorkshopCommand request, CancellationToken cancellationToken)
        {
            await _workshopService.ForceOpenWorkshop(request.WorkshopId!.Value);
        }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.HardDeleteProduct
{
    public class HardDeleteProductCommand : BaseCommand<Guid>, IRequest
    {
    }
}

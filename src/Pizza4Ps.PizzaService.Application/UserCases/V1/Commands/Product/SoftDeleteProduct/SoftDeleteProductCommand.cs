using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.SoftDeleteProduct
{
    public class SoftDeleteProductCommand : BaseCommand<Guid>, IRequest
    {
    }
}

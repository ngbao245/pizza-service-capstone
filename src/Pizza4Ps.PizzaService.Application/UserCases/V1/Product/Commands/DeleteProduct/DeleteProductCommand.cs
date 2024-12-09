using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.HardDeleteProduct
{
    public class DeleteProductCommand : BaseDeleteCommand, IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.CreateProductSize
{
    public class CreateProductSizeCommand: IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public string? Description { get; set; }
        public Guid ProductId { get; set; }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.CreateProductSize
{
    public class CreateProductSizeCommand: IRequest<ResultDto<Guid>>
    {
        public Guid ProductId { get; set; }
        public Guid RecipeId { get; set; }
        public Guid SizeId { get; set; }
    }
}

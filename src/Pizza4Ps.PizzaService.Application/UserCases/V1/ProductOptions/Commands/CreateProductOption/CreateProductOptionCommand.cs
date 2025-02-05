using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Commands.CreateProductOption
{
    public class CreateProductOptionCommand : IRequest<ResultDto<Guid>>
	{
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }
    }
}

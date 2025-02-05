using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem
{
    public class CreateOptionItemCommand : IRequest<ResultDto<Guid>>
	{
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionId { get; set; }
    }
}

using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItem
{
    public class UpdateOptionItemCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionId { get; set; }
    }
}

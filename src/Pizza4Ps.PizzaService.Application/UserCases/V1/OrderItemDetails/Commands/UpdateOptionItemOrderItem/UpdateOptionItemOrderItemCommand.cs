using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem
{
    public class UpdateOptionItemOrderItemCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionItemId { get; set; }
        public Guid OrderItemId { get; set; }
    }
}

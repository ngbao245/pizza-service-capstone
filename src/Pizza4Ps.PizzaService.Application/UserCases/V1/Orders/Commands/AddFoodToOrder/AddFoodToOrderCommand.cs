using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.AddFoodToOrder
{
    public class AddFoodToOrderCommand : IRequest<ResultDto<bool>>
    {
        public Guid TableId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public List<Guid> OptionItemIds { get; set; }
        public string Note { get; set; }
    }
}

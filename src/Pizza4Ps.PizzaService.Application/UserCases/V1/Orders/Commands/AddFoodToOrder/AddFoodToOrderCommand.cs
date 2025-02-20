using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.AddFoodToOrder
{
    public class AddFoodToOrderCommand : IRequest
    {
        public Guid TableId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }

        public List<Guid> OptionItemIds { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; }
    }
}
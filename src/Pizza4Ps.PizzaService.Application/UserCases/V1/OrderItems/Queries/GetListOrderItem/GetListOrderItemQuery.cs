using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
    public class GetListOrderItemQuery : PaginatedQuery<PaginatedResultDto<OrderItemDto>>
    {
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public OrderItemStatus? OrderItemStatus { get; set; }
    }
}

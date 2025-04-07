using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
    public class GetListOrderItemQuery : PaginatedQuery<PaginatedResultDto<OrderItemDto>>
    {
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public string? Type { get; set; }
        public List<string>? OrderItemStatus { get; set; }
    }
}

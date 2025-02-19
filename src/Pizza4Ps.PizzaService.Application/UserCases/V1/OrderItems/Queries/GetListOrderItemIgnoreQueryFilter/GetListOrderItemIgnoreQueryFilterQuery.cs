using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter
{
    public class GetListOrderItemIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<OrderItemDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public OrderItemTypeEnum? OrderItemStatus { get; set; }

    }
}

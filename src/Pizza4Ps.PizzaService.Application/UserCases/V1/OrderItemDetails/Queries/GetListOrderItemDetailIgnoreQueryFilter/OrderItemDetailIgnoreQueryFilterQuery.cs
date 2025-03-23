using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
    public class OrderItemDetailIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<OrderItemDetailDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public Guid? OrderItemId { get; set; }
    }
}

using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem
{
    public class GetListOrderItemDetailQuery : PaginatedQuery<PaginatedResultDto<OrderItemDetailDto>>
	{
        public string? Name { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public Guid? OptionItemId { get; set; }
        public Guid? OrderItemId { get; set; }
    }
}

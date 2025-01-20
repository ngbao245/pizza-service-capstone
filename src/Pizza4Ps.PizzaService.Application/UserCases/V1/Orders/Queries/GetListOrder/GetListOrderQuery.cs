using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrder
{
    public class GetListOrderQuery : PaginatedQuery<PaginatedResultDto<OrderDto>>
    {
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? Status { get; set; }
        public Guid? TableId { get; set; }
    }
}

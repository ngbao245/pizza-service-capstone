using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrderIgnoreQueryFilter
{
    public class GetListOrderIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<OrderDto>>
	{
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? Status { get; set; }
        public Guid? TableId { get; set; }
    }
}

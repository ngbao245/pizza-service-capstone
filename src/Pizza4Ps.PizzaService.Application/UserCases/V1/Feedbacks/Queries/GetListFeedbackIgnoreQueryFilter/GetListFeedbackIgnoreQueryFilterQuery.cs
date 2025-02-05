using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter
{
    public class GetListFeedbackIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<FeedbackDto>>
	{
        public bool IsDeleted { get; set; } = false;
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public Guid? OrderId { get; set; }
    }
}

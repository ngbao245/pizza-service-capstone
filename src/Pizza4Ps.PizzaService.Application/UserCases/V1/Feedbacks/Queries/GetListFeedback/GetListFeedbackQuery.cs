using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback
{
    public class GetListFeedbackQuery : PaginatedQuery<PaginatedResultDto<FeedbackDto>>
    {
        public int? Rating { get; set; }
        public string? Comments { get; set; }
        public Guid? OrderId { get; set; }
    }
}

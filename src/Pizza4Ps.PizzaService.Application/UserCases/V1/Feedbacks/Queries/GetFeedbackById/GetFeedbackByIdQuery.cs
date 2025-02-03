using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetFeedbackById
{
    public class GetFeedbackByIdQuery : IRequest<FeedbackDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

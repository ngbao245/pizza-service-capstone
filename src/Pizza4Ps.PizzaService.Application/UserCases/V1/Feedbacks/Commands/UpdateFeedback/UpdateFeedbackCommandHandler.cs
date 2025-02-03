using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.UpdateFeedback
{
	public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand>
	{
		private readonly IFeedbackService _feedbackService;

		public UpdateFeedbackCommandHandler(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		public async Task Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
		{
			var result = await _feedbackService.UpdateAsync(
				request.Id!.Value,
				request.Rating,
				request.Comments,
				request.OrderId);
		}
	}
}

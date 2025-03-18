using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.UpdateFeedback
{
    public class UpdateFeedbackCommand : IRequest
	{
		public Guid? Id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public Guid OrderId { get; set; }
    }
}

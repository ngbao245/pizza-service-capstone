using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommand : IRequest<ResultDto<Guid>>
	{
        public int Rating { get; set; }
        public string Comments { get; set; }
        public Guid OrderId { get; set; }
    }
}

using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.CreateFeedback
{
	public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackService _feedbackService;

		public CreateFeedbackCommandHandler(IMapper mapper, IFeedbackService feedbackService)
		{
			_mapper = mapper;
			_feedbackService = feedbackService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
		{
			var result = await _feedbackService.CreateAsync(
				request.Rating,
				request.Comments,
				request.OrderId);
            return new ResultDto<Guid>
            {
                Id = result,
            };
        }
	}
}

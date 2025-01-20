using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePayment
{
	public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentService _PaymentService;

		public CreatePaymentCommandHandler(IMapper mapper, IPaymentService PaymentService)
		{
			_mapper = mapper;
			_PaymentService = PaymentService;
		}

		public async Task<ResultDto<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
		{
			var result = await _PaymentService.CreateAsync(
				request.Amount,
				request.PaymentMethod,
				request.Status,
				request.OrderId);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}

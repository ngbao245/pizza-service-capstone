using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment
{
	public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
	{
		private readonly IPaymentService _PaymentService;

		public UpdatePaymentCommandHandler(IPaymentService PaymentService)
		{
			_PaymentService = PaymentService;
		}

		public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
		{
			var result = await _PaymentService.UpdateAsync(
				request.Id!.Value,
				request.Amount,
				request.PaymentMethod,
				request.Status,
				request.OrderId);
		}
	}
}

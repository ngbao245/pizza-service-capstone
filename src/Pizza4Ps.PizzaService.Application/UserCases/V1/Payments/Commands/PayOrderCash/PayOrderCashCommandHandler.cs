using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentQRCode;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.PayOrderCash
{
    public class PayOrderCashCommandHandler : IRequestHandler<PayOrderCashCommand, ResultDto<Guid>>
    {
        private readonly IPaymentService _paymentService;
        public PayOrderCashCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<ResultDto<Guid>> Handle(PayOrderCashCommand request, CancellationToken cancellationToken)
        {
            var result = await _paymentService.CreatePaymentCash(request.OrderId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}

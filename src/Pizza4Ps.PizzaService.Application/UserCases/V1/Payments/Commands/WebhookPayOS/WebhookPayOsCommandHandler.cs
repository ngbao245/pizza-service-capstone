using MediatR;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS
{
    public class WebhookPayOsCommandHandler : IRequestHandler<WebhookPayOsCommand, bool>
    {
        private readonly IPaymentService _paymentService;

        public WebhookPayOsCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(WebhookPayOsCommand request, CancellationToken cancellationToken)
        {
            //var webhookData = new WebhookData(
            //    orderCode: request.WebhookDto.Data.OrderCode,
            //    amount: request.WebhookDto.Data.Amount,
            //    description: request.WebhookDto.Data.Description,
            //    accountNumber: request.WebhookDto.Data.AccountNumber,
            //    reference: request.WebhookDto.Data.Reference,
            //    transactionDateTime: request.WebhookDto.Data.TransactionDateTime,
            //    currency: request.WebhookDto.Data.Currency,
            //    paymentLinkId: request.WebhookDto.Data.PaymentLinkId,
            //    code: request.WebhookDto.Data.Code,
            //    desc: request.WebhookDto.Data.Desc,
            //    counterAccountBankId: request.WebhookDto.Data.CounterAccountBankId,
            //    counterAccountBankName: request.WebhookDto.Data.CounterAccountBankName,
            //    counterAccountName: request.WebhookDto.Data.CounterAccountName,
            //    counterAccountNumber: request.WebhookDto.Data.CounterAccountNumber, 
            //    virtualAccountName: request.WebhookDto.Data.VirtualAccountName,
            //    virtualAccountNumber: request.WebhookDto.Data.VirtualAccountNumber);
            //var webhookType = new WebhookType(
            //    code: request.WebhookDto.Code,
            //    desc: request.WebhookDto.Desc,
            //    success: request.WebhookDto.Success,
            //    data: webhookData,
            //    signature: request.WebhookDto.Signature
            //    );
            var result = await _paymentService.ProcessWebhookData(request.WebhookDto);
            return result;
        }
    }
}

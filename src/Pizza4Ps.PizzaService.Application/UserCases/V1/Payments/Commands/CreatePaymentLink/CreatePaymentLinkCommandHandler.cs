using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentLink
{
    public class CreatePaymentLinkCommandHandler : IRequestHandler<CreatePaymentLinkCommand, string>
    {
        private readonly IPayOsService _payOsService;

        public CreatePaymentLinkCommandHandler(IPayOsService payOsService)
        {
            _payOsService = payOsService;
        }
        public async Task<string> Handle(CreatePaymentLinkCommand request, CancellationToken cancellationToken)
        {
            var result = await _payOsService.CreatePaymentLink(float.MinValue, "", "http://localhost:8001/api/categories");
            return result;
        }
    }
}

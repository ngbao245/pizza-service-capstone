using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentInfo
{
    public class GetPaymentInfoQueryHandler : IRequestHandler<GetPaymentInfoQuery>
    {
        private readonly IPayOsService _payOsService;

        public GetPaymentInfoQueryHandler(IPayOsService payOsService)
        {
            _payOsService = payOsService;
        }
        public async Task Handle(GetPaymentInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _payOsService.GetPaymentLinkInformation(request.OrderCode);
        }
    }
}

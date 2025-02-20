using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentInfo
{
    public class GetPaymentInfoQuery : IRequest
    {
        public long OrderCode { get; set; }
    }
}

using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
    public class GetListPaymentQuery : PaginatedQuery<PaginatedResultDto<PaymentDto>>
    {
        public decimal? Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid? OrderId { get; set; }
    }
}

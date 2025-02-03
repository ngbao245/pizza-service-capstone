using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
    public class GetListPaymentQuery : PaginatedQuery<PaginatedResultDto<PaymentDto>>
    {
        public decimal? Amount { get; set; } = decimal.Zero;
        public PaymentMethodEnum? PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
        public string? Status { get; set; }
        public Guid? OrderId { get; set; }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest
	{
		public Guid? Id { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.Cash;
        public string Status { get; set; }
        public Guid OrderId { get; set; }
    }
}

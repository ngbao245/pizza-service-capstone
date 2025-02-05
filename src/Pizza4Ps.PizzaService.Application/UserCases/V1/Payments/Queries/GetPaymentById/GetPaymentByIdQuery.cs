using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<PaymentDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

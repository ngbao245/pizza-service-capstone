using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetOrderVoucherById
{
    public class GetOrderVoucherByIdQuery : IRequest<OrderVoucherDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

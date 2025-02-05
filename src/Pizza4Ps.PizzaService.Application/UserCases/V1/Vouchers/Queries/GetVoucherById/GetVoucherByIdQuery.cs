using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherById
{
    public class GetVoucherByIdQuery : IRequest<VoucherDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

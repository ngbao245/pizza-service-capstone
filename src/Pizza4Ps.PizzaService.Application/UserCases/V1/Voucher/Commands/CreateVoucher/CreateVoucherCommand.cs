using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher
{
	public class CreateVoucherCommand : IRequest<CreateVoucherCommandResponse>
	{
		public CreateVoucherDto CreateVoucherDto { get; set; }

	}
}

﻿using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.RestoreVoucher
{
	public class RestoreVoucherCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}

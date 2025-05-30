﻿using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.UpdateVoucher
{
	public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand>
	{
		private readonly IVoucherService _voucherService;

		public UpdateVoucherCommandHandler(IVoucherService voucherService)
		{
			_voucherService = voucherService;
		}

		public async Task Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
		{
			var result = await _voucherService.UpdateAsync(
				request.Id!.Value,
				request.Code,
				request.DiscountType,
				request.ExpiryDate,
				request.VoucherTypeId);
		}
	}
}

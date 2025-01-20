using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.CreateOrderVoucher
{
	public class CreateOrderVoucherCommandHandler : IRequestHandler<CreateOrderVoucherCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherService _orderVoucherService;

		public CreateOrderVoucherCommandHandler(IMapper mapper, IOrderVoucherService orderVoucherService)
		{
			_mapper = mapper;
			_orderVoucherService = orderVoucherService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOrderVoucherCommand request, CancellationToken cancellationToken)
		{
			var result = await _orderVoucherService.CreateAsync(
				request.OrderId,
				request.VoucherId);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}

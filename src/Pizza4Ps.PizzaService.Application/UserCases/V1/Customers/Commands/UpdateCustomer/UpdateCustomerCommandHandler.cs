using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.UpdateCustomer
{
	public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
	{
		private readonly ICustomerService _customerService;

		public UpdateCustomerCommandHandler(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			var result = await _customerService.UpdateAsync(
				request.Id,
				request.UpdateCustomerDto.FullName,
				request.UpdateCustomerDto.Phone);
			return new UpdateCustomerCommandResponse
			{
				Id = result
			};
		}
	}
}

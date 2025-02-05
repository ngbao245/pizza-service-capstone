using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.UpdateCustomer
{
	public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
	{
		private readonly ICustomerService _customerService;

		public UpdateCustomerCommandHandler(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			var result = await _customerService.UpdateAsync(
				request.Id!.Value,
				request.FullName,
				request.Phone);
		}
	}
}

using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.DeleteCustomer
{
	public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
	{
		private readonly ICustomerService _customerService;

		public DeleteCustomerCommandHandler(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			await _customerService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}

using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
	public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
	{
		public UpdateCustomerDto UpdateCustomerDto { get; set; }
	}
}

using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.UpdateCustomer
{
	public class UpdateCustomerCommand : IRequest<UpdateCustomerCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateCustomerDto UpdateCustomerDto { get; set; }
	}
}

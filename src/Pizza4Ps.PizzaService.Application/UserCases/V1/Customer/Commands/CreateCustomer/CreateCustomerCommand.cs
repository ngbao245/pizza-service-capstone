using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.CreateCategory;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.CreateCustomer
{
	public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
	{
		public string FullName { get; set; }
		public string Phone { get; set; }
	}
}

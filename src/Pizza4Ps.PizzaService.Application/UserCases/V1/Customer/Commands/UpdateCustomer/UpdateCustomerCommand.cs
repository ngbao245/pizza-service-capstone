using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.UpdateCustomer
{
	public class UpdateCustomerCommand : BaseUpdateCommand<Guid>, IRequest<UpdateCustomerCommandResponse>
	{
		public string FullName { get; set; }
		public string Phone { get; set; }
	}
}

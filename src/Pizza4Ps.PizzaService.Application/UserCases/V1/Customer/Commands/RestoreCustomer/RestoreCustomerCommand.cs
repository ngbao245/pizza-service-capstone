using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.RestoreCustomer
{
	public class RestoreCustomerCommand : BaseRestoreCommand<Guid>, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}

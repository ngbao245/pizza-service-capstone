using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : BaseDeleteCommand, IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}

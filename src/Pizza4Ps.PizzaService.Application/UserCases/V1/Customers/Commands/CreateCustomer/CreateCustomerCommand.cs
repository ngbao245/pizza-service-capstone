using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}

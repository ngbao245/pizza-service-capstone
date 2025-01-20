using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<ResultDto<Guid>>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}

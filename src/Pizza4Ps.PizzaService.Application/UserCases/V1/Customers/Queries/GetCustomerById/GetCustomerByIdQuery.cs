using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

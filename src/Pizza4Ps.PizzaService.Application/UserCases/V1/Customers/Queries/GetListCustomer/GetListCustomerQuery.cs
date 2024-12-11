using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQuery : PaginatedRequestDto, IRequest<GetListCustomerQueryResponse>
    {
        public bool IsDeleted { get; set; } = false;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
    }
}

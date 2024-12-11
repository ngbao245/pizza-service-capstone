using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.Models;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryResponse : PaginatedResult<CustomerDto>
    {
        public GetListCustomerQueryResponse(List<CustomerDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}

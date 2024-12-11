using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryResponse : PaginatedResultDto<CustomerDto>
    {
        public GetListCustomerQueryResponse(List<CustomerDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}

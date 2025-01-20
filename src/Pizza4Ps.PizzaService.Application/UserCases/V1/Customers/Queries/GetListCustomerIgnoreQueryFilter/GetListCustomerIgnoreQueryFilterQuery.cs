using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<CustomerDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? FullName { get; set; }
        public string? Phone { get; set; }
    }
}

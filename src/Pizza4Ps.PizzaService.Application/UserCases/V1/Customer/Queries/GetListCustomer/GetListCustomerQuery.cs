using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Queries.GetListCustomer
{
	public class GetListCustomerQuery : BasePaginatedQuery, IRequest<GetListCustomerQueryResponse>
	{
		public bool IsDeleted { get; set; } = false;
		public string? FullName { get; set; }
		public string? Phone { get; set; }
	}
}

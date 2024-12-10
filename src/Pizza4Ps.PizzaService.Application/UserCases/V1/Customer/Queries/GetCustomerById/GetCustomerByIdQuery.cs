using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Queries;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Queries.GetCustomerById
{
	public class GetCustomerByIdQuery : BaseGetSingleByIdQuery<Guid>, IRequest<GetCustomerByIdQueryResponse>
	{
	}
}

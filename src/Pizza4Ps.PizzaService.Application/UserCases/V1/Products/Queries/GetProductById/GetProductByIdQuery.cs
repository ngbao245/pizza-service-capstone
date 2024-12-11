using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Queries;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : BaseGetSingleByIdQuery<Guid>, IRequest<GetProductByIdQueryResponse>
    {
    }
}

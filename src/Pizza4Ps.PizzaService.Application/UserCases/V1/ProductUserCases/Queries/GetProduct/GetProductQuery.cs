using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery;
using Pizza4Ps.PizzaService.Application.Models;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Queries.GetProduct
{
    public class GetProductQuery : BasePaginatedQuery, IRequest<PaginatedResult<GetProductQueryResponse>>
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}

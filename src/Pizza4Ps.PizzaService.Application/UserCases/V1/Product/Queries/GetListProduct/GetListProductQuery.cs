using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery;
using Pizza4Ps.PizzaService.Application.Models;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProduct
{
    public class GetListProductQuery : BasePaginatedQuery, IRequest<GetListProductQueryResponse>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}

using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.Models;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProduct
{
    public class GetListProductQueryResponse : PaginatedResult<ProductDto>
    {
        public GetListProductQueryResponse(List<ProductDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}

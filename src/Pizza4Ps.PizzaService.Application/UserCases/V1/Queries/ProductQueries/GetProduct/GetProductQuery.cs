using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery;
using Pizza4Ps.PizzaService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.ProductQueries.GetProduct
{
    public class GetProductQuery : BasePaginatedQuery, IRequest<PaginatedResult<GetProductQueryResponse>>
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}

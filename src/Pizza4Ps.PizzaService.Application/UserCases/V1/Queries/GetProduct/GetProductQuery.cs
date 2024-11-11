using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.GetListProduct
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

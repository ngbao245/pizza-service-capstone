using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductOption
{
    public class GetProductOptionQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {


        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

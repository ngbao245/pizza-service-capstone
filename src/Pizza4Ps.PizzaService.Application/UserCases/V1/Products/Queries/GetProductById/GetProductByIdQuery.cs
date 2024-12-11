using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResponse>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}

using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProductStatus
{
    public class UpdateProductStatusCommand : IRequest
    {
        public Guid? Id { get; set; }

        public string ProductStatus { get; set; }   
    }
}

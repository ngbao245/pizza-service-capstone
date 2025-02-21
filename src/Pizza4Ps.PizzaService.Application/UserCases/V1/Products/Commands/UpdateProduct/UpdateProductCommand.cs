using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public ProductTypeEnum.ProductType ProductType { get; set; }
    }
}




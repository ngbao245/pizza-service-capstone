using MediatR;
using Microsoft.AspNetCore.Http;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile? file { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductType { get; set; }
        public string? ProductOptionModels { get; set; }
    }
    public class CreateProductOptionModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool SelectMany { get; set; }
        public List<CreateProductOptionItemModel> ProductOptionItemModels { get; set; } = new List<CreateProductOptionItemModel>();
    }
    public class CreateProductOptionItemModel
    {
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}

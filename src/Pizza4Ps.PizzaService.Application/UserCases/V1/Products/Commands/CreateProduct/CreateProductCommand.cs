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
        public List<Guid>? OptionIds { get; set; }
        /// <summary>
        /// Danh sách size (child products)
        /// </summary>
        public string? Sizes { get; set; }

    }
    public class CreateProductSizeModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

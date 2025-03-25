using MediatR;
using Microsoft.AspNetCore.Http;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public IFormFile? file { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}

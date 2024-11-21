using AutoMapper;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
        }
    }
}

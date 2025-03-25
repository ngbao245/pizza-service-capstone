using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSize, ProductSizeDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductProfile : Profile
	{
		public ProductProfile()
		{
            CreateMap<ProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => Enum.GetName(typeof(ProductTypeEnum), src.ProductType)))
                .ForMember(dest => dest.ProductRole, opt => opt.MapFrom(src => Enum.GetName(typeof(ProductRoleEnum), src.ProductRole)))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(ProductStatus), src.ProductStatus)));


        }
    }
}

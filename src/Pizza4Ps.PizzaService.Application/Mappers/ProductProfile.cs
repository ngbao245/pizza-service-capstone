using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDto, Product>().ReverseMap();

            CreateMap<Product, ProductMenuDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.ProductOptions.Select(po => po.Option).ToList()));

            CreateMap<Option, OptionMenuDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OptionItems));

            CreateMap<OptionItem, OptionItemMenuDto>();
        }
	}
}

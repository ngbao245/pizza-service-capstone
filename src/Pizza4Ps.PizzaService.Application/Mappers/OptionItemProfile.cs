using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class OptionItemProfile : Profile
	{
		public OptionItemProfile()
		{
			CreateMap<OptionItemDto, OptionItem>().ReverseMap()
				.ForMember(dest => dest.OptionItemStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(OptionItemStatus), src.OptionItemStatus)));
        }
	}
}

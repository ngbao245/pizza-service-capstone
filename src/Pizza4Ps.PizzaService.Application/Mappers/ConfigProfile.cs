using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ConfigProfile : Profile
    {
        public ConfigProfile()
        {
            CreateMap<ConfigDto, Config>().ReverseMap()
                .ForMember(dest => dest.ConfigType, opt => opt.MapFrom(src => Enum.GetName(typeof(ConfigType), src.ConfigType)));
        }
    }
}

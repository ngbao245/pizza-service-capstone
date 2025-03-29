using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<ZoneDto, Zone>().ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.GetName(typeof(ZoneTypeEnum), src.Type)));

        }
    }
}

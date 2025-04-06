using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ReasonConfigProfile : Profile
    {
        public ReasonConfigProfile()
        {
            CreateMap<ReasonConfig, ReasonConfigDto>().ReverseMap()
                .ForMember(dest => dest.ReasonType, opt => opt.MapFrom(src => Enum.GetName(typeof(ReasonConfigTypeEnum), src.ReasonType)));
        }
    }
}

using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<OptionDto, Option>().ReverseMap()
                .ForMember(dest => dest.OptionStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(OptionStatus), src.OptionStatus)));

        }
    }
}

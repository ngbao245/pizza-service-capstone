using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffDto, Staff>().ReverseMap()
            .ForMember(dest => dest.StaffType, opt => opt.MapFrom(src => Enum.GetName(typeof(StaffTypeEnum), src.StaffType)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(StaffStatusEnum), src.Status)));
        }
    }
}

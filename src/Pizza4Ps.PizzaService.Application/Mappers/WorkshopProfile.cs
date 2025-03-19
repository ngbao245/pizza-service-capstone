using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class WorkshopProfile : Profile
    {
        public WorkshopProfile()
        {
            CreateMap<Workshop, WorkshopDto>()
                .ForMember(dest => dest.WorkshopStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(WorkshopStatus), src.WorkshopStatus!)));
        
        }
    }
}

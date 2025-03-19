using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class WorkshopRegisterProfile : Profile
    {
        public WorkshopRegisterProfile()
        {
            CreateMap<WorkshopRegister, WorkshopRegisterDto>()
                .ForMember(dest => dest.WorkshopRegisterStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(WorkshopRegisterStatus), src.WorkshopRegisterStatus!)));
        }
    }
}

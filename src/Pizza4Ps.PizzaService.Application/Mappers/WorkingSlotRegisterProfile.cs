using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class WorkingSlotRegisterProfile : Profile
    {
        public WorkingSlotRegisterProfile()
        {
            CreateMap<WorkingSlotRegisterDto, WorkingSlotRegister>().ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(WorkingSlotRegisterStatusEnum), src.Status)));
        }
    }
}

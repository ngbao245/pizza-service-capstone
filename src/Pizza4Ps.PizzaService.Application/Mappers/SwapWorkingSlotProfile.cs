using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class SwapWorkingSlotProfile:Profile
    {
        public SwapWorkingSlotProfile()
        {
            CreateMap<SwapWorkingSlotDto, SwapWorkingSlot>().ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(SwapWorkingSlotStatusEnum), src.Status)));
        }
    }
}

using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            //CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<PaymentDto, Payment>().ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentStatusEnum), src.Status)))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentMethodEnum), src.PaymentMethod)));
        }
    }
}

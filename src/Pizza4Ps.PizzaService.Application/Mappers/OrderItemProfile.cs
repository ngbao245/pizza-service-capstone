using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class OrderItemProfile : Profile
	{
		public OrderItemProfile()
		{
			CreateMap<OrderItemDto, OrderItem>().ReverseMap()
                .ForMember(dest => dest.OrderItemStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(OrderItemStatus), src.OrderItemStatus)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.GetName(typeof(OrderTypeEnum), src.Type)));
        }
    }
}

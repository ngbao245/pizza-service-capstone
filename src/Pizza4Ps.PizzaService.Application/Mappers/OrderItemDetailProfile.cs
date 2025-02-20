using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class OrderItemDetailProfile : Profile
	{
		public OrderItemDetailProfile()
		{
			CreateMap<OrderItemDetailDto, OrderItemDetail>().ReverseMap();
		}
	}
}

using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ZoneProfile : Profile
	{
		public ZoneProfile()
		{
			CreateMap<ZoneDto, Zone>().ReverseMap();
		}
	}
}

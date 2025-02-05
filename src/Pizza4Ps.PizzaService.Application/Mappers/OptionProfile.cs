using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<OptionDto, Option>().ReverseMap();
        }
    }
}

using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<TableDto, Table>().ReverseMap();
        }
    }
}


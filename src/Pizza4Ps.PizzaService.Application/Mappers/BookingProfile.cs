using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDto, Booking>().ReverseMap()
                .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(BookingStatusEnum), src.BookingStatus)));
        }
    }
}

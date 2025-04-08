using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.BookingStatus.ToString()))
                .ForMember(dest => dest.ReservationPriorityStatus, opt => opt.MapFrom(src => src.ReservationPriorityStatus.ToString()))
                .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Table != null ? src.Table : null))
                .ReverseMap();
        }
    }
}

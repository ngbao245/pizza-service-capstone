using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter
{
    public class GetListBookingIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<BookingDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? BookingDate { get; set; }
        public int? GuestCount { get; set; }
        public string? Status { get; set; }
        public Guid? CustomerId { get; set; }
    }
}

using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetListTableBookingIgnoreQueryFilter
{
    public class GetListTableBookingIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<TableBookingDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? OnholdTime { get; set; }
        public Guid? TableId { get; set; }
        public Guid? BookingId { get; set; }
    }
}

using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Queries.GetReservationSlotList
{
    public class GetReservationSlotListQuery : PaginatedQuery<PaginatedResultDto<ReservationSlotDto>>
    {
    }
}

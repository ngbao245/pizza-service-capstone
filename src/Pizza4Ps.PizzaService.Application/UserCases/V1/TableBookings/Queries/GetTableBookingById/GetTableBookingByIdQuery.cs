using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Queries.GetTableBookingById
{
    public class GetTableBookingByIdQuery : IRequest<TableBookingDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

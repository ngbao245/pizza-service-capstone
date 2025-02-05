using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetStaffById
{
    public class GetStaffByIdQuery : IRequest<StaffDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}

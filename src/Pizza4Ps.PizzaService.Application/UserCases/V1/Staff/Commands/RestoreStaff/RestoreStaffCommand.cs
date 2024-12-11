using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.RestoreStaff
{
	public class RestoreStaffCommand : BaseRestoreCommand<Guid>, IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}

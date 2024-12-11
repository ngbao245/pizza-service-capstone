using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.UpdateStaff;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.UpdateOption
{
	public class UpdateOptionCommand : BaseUpdateCommand<Guid>, IRequest<UpdateOptionCommandResponse>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}

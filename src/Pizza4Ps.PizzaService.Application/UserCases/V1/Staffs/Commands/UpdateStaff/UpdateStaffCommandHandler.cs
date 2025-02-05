using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.UpdateStaff
{
	public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand>
	{
		private readonly IStaffService _staffService;

		public UpdateStaffCommandHandler(IStaffService staffService)
		{
			_staffService = staffService;
		}

		public async Task Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
		{
			var result = await _staffService.UpdateAsync(
				request.Id!.Value,
				request.Code,
				request.Name,
				request.Phone,
				request.Email,
				request.StaffType,
				request.Status);
		}
	}
}

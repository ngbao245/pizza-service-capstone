using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.UpdateStaff
{
	public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, UpdateStaffCommandResponse>
	{
		private readonly IStaffService _staffService;

		public UpdateStaffCommandHandler(IStaffService staffService)
		{
			_staffService = staffService;
		}

		public async Task<UpdateStaffCommandResponse> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
		{
			var result = await _staffService.UpdateAsync(request.Id, request.Code, request.Name, request.Phone, request.Email, request.StaffType, request.Status);
			return new UpdateStaffCommandResponse
			{
				Id = result
			};
		}
	}
}

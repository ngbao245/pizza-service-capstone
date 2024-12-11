using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.CreateStaff
{
	public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, CreateStaffCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IStaffService _staffService;

		public CreateStaffCommandHandler(IMapper mapper, IStaffService staffService)
		{
			_mapper = mapper;
			_staffService = staffService;
		}

		public async Task<CreateStaffCommandResponse> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
		{
			var result = await _staffService.CreateAsync(request.Code, request.Name, request.Phone, request.Email, request.StaffType, request.Status);
			return new CreateStaffCommandResponse
			{
				Id = result
			};
		}
	}
}

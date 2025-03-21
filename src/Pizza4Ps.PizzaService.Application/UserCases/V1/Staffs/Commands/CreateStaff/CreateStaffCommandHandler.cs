using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.CreateStaff
{
	public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IStaffService _staffService;

		public CreateStaffCommandHandler(IMapper mapper, IStaffService staffService)
		{
			_mapper = mapper;
			_staffService = staffService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
		{
			var result = await _staffService.CreateAsync(
				request.FullName,
				request.Phone,
				request.Email,
				request.StaffType,
				request.Status);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}

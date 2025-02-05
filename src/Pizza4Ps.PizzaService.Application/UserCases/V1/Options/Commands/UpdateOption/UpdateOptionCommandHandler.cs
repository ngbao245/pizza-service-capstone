using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOption
{
	public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand>
	{
		private readonly IOptionService _optionService;

		public UpdateOptionCommandHandler(IOptionService optionService)
		{
			_optionService = optionService;
		}

		public async Task Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.Description);
		}
	}
}

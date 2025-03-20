using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResultDto<Guid>>
	{
		private readonly ICategoryService _categoryService;

		public CreateCategoryCommandHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var result = await _categoryService.CreateAsync(
				request.Name,
				request.Description);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
	}
}

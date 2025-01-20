using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateAsync(
                request.Id,
                request.Name,
                request.Description);
        }
    }
}

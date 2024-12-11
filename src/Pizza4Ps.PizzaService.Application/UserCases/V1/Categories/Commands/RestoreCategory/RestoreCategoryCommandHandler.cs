using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommandHandler : IRequestHandler<RestoreCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public RestoreCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Handle(RestoreCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.RestoreAsync(request.Ids);
        }
    }
}

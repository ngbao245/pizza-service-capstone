using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class RecipeService : DomainService, IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        public async Task<Guid> CreateAsync(string unit, string name)
        {
            var entity = new Recipe(Guid.NewGuid(), unit, name);
            _recipeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}

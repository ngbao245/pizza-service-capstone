using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class IngredientgService : DomainService, IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientgService(IUnitOfWork unitOfWork, IIngredientRepository ingredientRepository)
        {
            _unitOfWork = unitOfWork;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Guid> CreateAsync(string name, string description, decimal price)
        {
            var entity = new Ingredient(Guid.NewGuid(), name, description, price);
            _ingredientRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}

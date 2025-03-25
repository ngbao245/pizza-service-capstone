using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class RecipeService : DomainService, IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository, IProductSizeRepository productSizeRepository, IIngredientRepository ingredientRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _productSizeRepository = productSizeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Guid> CreateAsync(Guid productSizeId, Guid? ingredientId, string ingredientName, UnitOfMeasurementType unit, decimal quantity)
        {
            var existingProductSize = await _productSizeRepository.CountAsync(p => p.Id == productSizeId);
            if (existingProductSize == 0)
            {
                throw new BusinessException(BussinessErrorConstants.ProductSizeErrorConstant.PRODUCTSIZE_NOT_FOUND);
            }

            var entity = new Recipe(Guid.NewGuid(), productSizeId, ingredientId, ingredientName, unit, quantity);
            _recipeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}

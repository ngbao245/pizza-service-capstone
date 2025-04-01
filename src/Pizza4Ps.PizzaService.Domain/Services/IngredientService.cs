using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class IngredientService : DomainService, IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IUnitOfWork unitOfWork, IIngredientRepository ingredientRepository)
        {
            _unitOfWork = unitOfWork;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Guid> CreateAsync(string name, string description)
        {
            var entity = new Ingredient(Guid.NewGuid(), name, description);
            _ingredientRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(List<Guid> ids, bool isHardDelete)
        {
            var entities = await _ingredientRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (!entities.Any()) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                if (isHardDelete)
                {
                    _ingredientRepository.HardDelete(entity);
                }
                else
                {
                    _ingredientRepository.SoftDelete(entity);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task RestoreAsync(List<Guid> ids)
        {
            var entities = await _ingredientRepository.GetListAsTracking(x => ids.Contains(x.Id)).IgnoreQueryFilters().ToListAsync();
            if (entities == null) throw new ServerException(ServerErrorConstants.NOT_FOUND);
            foreach (var entity in entities)
            {
                _ingredientRepository.Restore(entity);
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

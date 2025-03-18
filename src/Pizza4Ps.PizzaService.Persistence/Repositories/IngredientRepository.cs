using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class IngredientRepository : RepositoryBase<Ingredient, Guid>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}

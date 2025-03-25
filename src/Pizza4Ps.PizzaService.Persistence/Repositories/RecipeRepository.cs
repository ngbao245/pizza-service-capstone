using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Persistence.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
    }
}

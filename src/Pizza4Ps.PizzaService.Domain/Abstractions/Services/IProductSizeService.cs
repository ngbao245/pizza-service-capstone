using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IProductSizeService
    {
        Task<Guid> CreateAsync(string productId, string recipeId, string sizeId);
    }
}

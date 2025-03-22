using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ProductSizeService : DomainService, IProductSizeService
    {
        public Task<Guid> CreateAsync(string productId, string recipeId, string sizeId)
        {
            throw new NotImplementedException();
        }
    }
}

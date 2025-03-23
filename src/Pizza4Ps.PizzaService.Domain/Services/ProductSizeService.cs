using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ProductSizeService : DomainService, IProductSizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeService(IUnitOfWork unitOfWork, IProductSizeRepository productSizeRepository)
        {
            _unitOfWork = unitOfWork;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<Guid> CreateAsync(Guid productId, Guid recipeId, Guid sizeId)
        {
            var entity = new ProductSize(Guid.NewGuid(), productId, recipeId, sizeId);
            _productSizeRepository.Add(entity);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
    }
}

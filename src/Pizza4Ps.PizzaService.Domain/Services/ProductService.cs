using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork
            , IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        
        public async Task<Guid> CreateProductAsync(Product product)
        {
            var existedEntity = _productRepository.GetByIdAsync(product.Id);
            if (existedEntity == null) throw new BusinessException("Invalid name");
            var productEntity = new Product(product.Id, product.Name, product.Price, product.Description, product.CategoryId);
            _productRepository.Add(productEntity);
            await _unitOfWork.SaveChangeAsync();
            return productEntity.Id;
        }
        public async Task<Guid> UpdateProductAsync(Guid id, string name, decimal price, string description, Guid categoryId)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            entity.UpdateProduct(name, price, description, categoryId);
            await _unitOfWork.SaveChangeAsync();
            return entity.Id;
        }
        public async Task HardDeleteProductAsync(Guid id)
        {
            await _productRepository.HardDeleteAsync(id);
        }
        public async Task SoftDeleteProductAsync(Guid id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            _productRepository.SoftDelete(entity);
            await _unitOfWork.SaveChangeAsync();
        }

    }
}

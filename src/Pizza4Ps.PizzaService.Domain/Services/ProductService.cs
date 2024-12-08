using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;

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
        
        public async Task<Guid> CreateProductAsync(string name, decimal price, string description, Guid categoryId)
        {
            var productEntity = new Product(Guid.NewGuid(), name, price, description, categoryId);
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
            var entity = await _productRepository.GetAsTrackingAsync(x => x.Id == id).IgnoreQueryFilters().FirstOrDefaultAsync();
            if (entity == null) throw new NotFoundException("Entity not found");
            _productRepository.HardDelete(entity);
            await _unitOfWork.SaveChangeAsync();
        }
        public async Task SoftDeleteProductAsync(Guid id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            if (entity == null) throw new NotFoundException("Entity not found");
            _productRepository.SoftDelete(entity);
            await _unitOfWork.SaveChangeAsync();
        }

    }
}

using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Constants;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class ProductSizeService : DomainService, IProductSizeService
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductSizeService(IProductSizeRepository productSizeRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productSizeRepository = productSizeRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(string name, decimal diameter, string description, Guid productId)
        {

            var existingProduct = await _productRepository.GetSingleByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            }

            var duplicateSize = await _productSizeRepository.CountAsync(
                ps => ps.Name == name || ps.Diameter == diameter);
            if (duplicateSize > 0)
            {
                throw new BusinessException(BussinessErrorConstants.ProductSizeErrorConstant.PRODUCTSIZE_EXISTED);
            }

            var productSize = new ProductSize(Guid.NewGuid(), name, diameter, description, productId);
            _productSizeRepository.Add(productSize);
            await _unitOfWork.SaveChangeAsync();

            return productSize.Id;
        }
    }
}

using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{
        private readonly Cloudinary _cloudinary;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

		public UpdateProductCommandHandler(IProductService productService, IProductRepository productRepository,
            Cloudinary cloudinary)
		{
            _cloudinary = cloudinary;
            _productRepository = productRepository;
            _productService = productService;
		}

		public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
            string? imageUrl = null;
            string? imagePublicId = null;
            if (request.file != null && request.file.Length != 0)
            {
                var product = await _productRepository.GetSingleByIdAsync(request.Id!.Value);
                if (product == null)
                    throw new BusinessException("Product not found");
                using var stream = request.file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(request.file.FileName, stream),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };        
                // Nếu đã có ảnh trước đó, ghi đè bằng public_id
                if (!string.IsNullOrEmpty(product.ImagePublicId))
                {
                    uploadParams.PublicId = product.ImagePublicId; // Ghi đè ảnh cũ
                }

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                    throw new BusinessException("Upload image failed");
                // Cập nhật product với ảnh mới
                imageUrl = uploadResult.SecureUrl.ToString();
                imagePublicId = uploadResult.PublicId;
            }
            var result = await _productService.UpdateAsync(
				request.Id!.Value,
				request.Name,
				request.Price,
                request.Image,
                request.Description,
				request.CategoryId,
				request.ProductType,
                imageUrl,
                imagePublicId
                );
		}
	}
}

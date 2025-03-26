using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateImageProduct
{
    public class UpdateImageProductCommandHandler : IRequestHandler<UpdateImageProductCommand>
    {
        private readonly Cloudinary _cloudinary;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public UpdateImageProductCommandHandler(IProductRepository productRepository,
            IUnitOfWork unitOfWork, Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task Handle(UpdateImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleByIdAsync(request.Id);
            if (product == null)
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            }
            string? imageUrl = null;
            string? imagePublicId = null;
            if (request.file != null && request.file.Length != 0)
            {
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
            product.UpdateImage(imageUrl, imagePublicId);
            _productRepository.Update(product);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}

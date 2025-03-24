using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultDto<Guid>>
    {
        private readonly Cloudinary _cloudinary;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IMapper mapper, IProductService productService, Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
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
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                    throw new BusinessException("Upload image failed");
                // Cập nhật product với ảnh mới
                imageUrl = uploadResult.SecureUrl.ToString();
                imagePublicId = uploadResult.PublicId;
            }

            var result = await _productService.CreateAsync(
                request.Name,
                request.Price,
                request.Image,
                request.Description,
                request.CategoryId,
                request.ProductType, 
                imageUrl,
                imagePublicId);


            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}

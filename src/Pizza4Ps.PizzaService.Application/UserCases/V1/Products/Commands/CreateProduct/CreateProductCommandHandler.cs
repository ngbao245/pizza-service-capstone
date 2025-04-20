using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Newtonsoft.Json;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultDto<Guid>>
    {
        private readonly IProductOptionRepository _productOptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly Cloudinary _cloudinary;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IMapper mapper,
            IProductService productService,
            IOptionRepository optionRepository,
            IOptionItemRepository optionItemRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            Cloudinary cloudinary,
            IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _optionItemRepository = optionItemRepository;
            _optionRepository = optionRepository;
            _cloudinary = cloudinary;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string? imageUrl = null;
            string? imagePublicId = null;
            try
            {
                // Upload ảnh nếu có
                if (request.file != null && request.file.Length > 0)
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

                    imageUrl = uploadResult.SecureUrl.ToString();
                    imagePublicId = uploadResult.PublicId;
                }
                // Validate product type
                if (!Enum.TryParse(request.ProductType, true, out ProductTypeEnum productTypeEnum))
                {
                    throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_TYPE);
                }
                // Tạo product entity
                var product = new Product(
                    Guid.NewGuid(),
                    name: request.Name,
                    price: request.Price,
                    null,
                    description: request.Description,
                    categoryId: request.CategoryId,
                    productType: productTypeEnum,
                    imageUrl: imageUrl,
                    imagePublicId: imagePublicId,
                    productRole: ProductRoleEnum.Master,
                    parentProductId: null
                );
                if (request.OptionIds != null)
                {
                    foreach (var optionId in request.OptionIds)
                    {
                        var productOption = new ProductOption(productId: product.Id,
                            optionId: optionId);
                        _productOptionRepository.Add(productOption);
                    }
                }

                var sizes = new List<CreateProductSizeModel>();
                if (!string.IsNullOrWhiteSpace(request.Sizes))
                {
                    sizes = JsonConvert
                        .DeserializeObject<List<CreateProductSizeModel>>(request.Sizes)
                        ?? new List<CreateProductSizeModel>(); // phòng null :contentReference[oaicite:0]{index=0}
                }
                // 4. Tạo các size (child products)
                foreach (var s in sizes)
                {
                    var child = new Product(
                    Guid.NewGuid(),
                    name: $"{request.Name} - {s.Name}",
                    price: s.Price,
                    null,
                    description: null,
                    categoryId: request.CategoryId,
                    productType: productTypeEnum,
                    imageUrl: null,
                    imagePublicId: null,
                    productRole: ProductRoleEnum.Child,
                    parentProductId: product.Id
                    );
                    _productRepository.Add(child);
                }
                // Thêm product, option và option item vào repository
                _productRepository.Add(product);
                await _unitOfWork.SaveChangeAsync(cancellationToken);
                return new ResultDto<Guid>
                {
                    Id = product.Id,
                };
            }
            catch (Exception)
            {
                // Nếu có lỗi, xóa ảnh đã upload (nếu có)
                if (!string.IsNullOrEmpty(imagePublicId))
                {
                    await _cloudinary.DeleteResourcesAsync(new DelResParams
                    {
                        PublicIds = new List<string> { imagePublicId }
                    });
                }
                throw;
            }
        }
    }
}

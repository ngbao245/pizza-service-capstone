using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultDto<Guid>>
    {
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
            Cloudinary cloudinary)
        {
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
            if (!Enum.TryParse(request.ProductType, true, out ProductTypeEnum productTypeEnum))
            {
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.INVALID_PRODUCT_TYPE);
            }
            var product = new Product(Guid.NewGuid(),
                name: request.Name,
                price: request.Price,
                null,
                description: request.Description,
                categoryId: request.CategoryId,
                productType: productTypeEnum,
                imageUrl: null,
                imagePublicId: null);
            var options = new List<Option>();
            var optionItems = new List<OptionItem>();
            foreach (var optionModel in request.ProductOptionModels)
            {
                var option = new Option(Guid.NewGuid(), product.Id, optionModel.Name, optionModel.Description);
                options.Add(option);
                foreach (var optionItem in option.OptionItems)
                {
                    optionItems.Add(new OptionItem(Guid.NewGuid(), optionItem.Name, optionItem.AdditionalPrice, option.Id));
                }
            }
            _productRepository.Add(product);
            _optionRepository.AddRange(options);
            _optionItemRepository.AddRange(optionItems);
            await _unitOfWork.SaveChangeAsync();
            return new ResultDto<Guid>
            {
                Id = product.Id,
            };
        }
    }
}

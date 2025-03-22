using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.CreateProductSize
{
    internal class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeService _productSizeService;

        public CreateProductSizeCommandHandler(IMapper mapper, IProductSizeService productSizeService)
        {
            _mapper = mapper;
            _productSizeService = productSizeService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var result = await _productSizeService.CreateAsync(
                request.ProductId,
                request.RecipeId,
                request.SizeId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}

using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.CreateProductSize
{
    public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, ResultDto<Guid>>
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
                request.Name,
                request.Diameter,
                request.Description,
                request.ProductId
                );
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}

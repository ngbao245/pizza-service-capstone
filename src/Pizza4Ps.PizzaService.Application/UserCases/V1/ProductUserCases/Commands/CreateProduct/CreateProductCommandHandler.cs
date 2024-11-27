using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public CreateProductCommandHandler(IMapper mapper
            , ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var result = await _productService.CreateProductAsync(product);
            return result;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Commands.CreateProductSize;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizeById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetProductSizesByProduct;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/product-sizes")]
    [ApiController]
    public class ProductSizesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public ProductSizesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductSizeCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListProductSizeQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id, string includeProperties = "")
        {
            var result = await _sender.Send(new GetProductSizeByIdQuery { Id = id, includeProperties = includeProperties });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("get-productsizes-by-product")]
        public async Task<IActionResult> GetByProductId([FromQuery] Guid productId)
        {
            var result = await _sender.Send(new GetProductSizesByProductQuery { ProductId = productId });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

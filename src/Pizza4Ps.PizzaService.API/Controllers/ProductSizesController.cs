using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/productsizes")]
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
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetProductByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

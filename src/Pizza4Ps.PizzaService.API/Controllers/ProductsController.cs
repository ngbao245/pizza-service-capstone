using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.HardDeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.SoftDeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.Product.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.Product.GetProduct;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public ProductsController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync([FromQuery] GetProductQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromQuery] UpdateProductCommand command)
        {
            //var result = await _sender.Send(command);
            return Ok(new ApiResponse
            {
                //Result = result,
                Message = MESSSAGE.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("set-is-deleted/{id}")]
        public async Task<IActionResult> SoftDeleteProductAsync(Guid id)
        {
            await _sender.Send(new SoftDeleteProductCommand { Id = id});
            return Ok(new ApiResponse
            {
                Message = MESSSAGE.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDeleteProductAsync(Guid id)
        {
            await _sender.Send(new HardDeleteProductCommand { Id = id });
            return Ok(new ApiResponse
            {
                Message = MESSSAGE.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.CreateProduct;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new ApiResponse<Guid>
            {
                Data = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync([FromBody] CreateProductCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new ApiResponse<Guid>
            {
                Data = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

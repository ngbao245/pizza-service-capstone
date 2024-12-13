using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.CreateOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.DeleteOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.RestoreOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Commands.UpdateOrder;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public OrdersController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderDto request)
        {
            var result = await _sender.Send(new CreateOrderCommand { CreateOrderDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetListAsync([FromQuery] GetListProductQuery query)
        //{
        //	var result = await _sender.Send(query);
        //	return Ok(new ApiResponse
        //	{
        //		Result = result,
        //		Message = MESSAGE.GET_SUCCESS,
        //		StatusCode = StatusCodes.Status200OK
        //	});
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        //{
        //	var result = await _sender.Send(new GetProductByIdQuery { Id = id });
        //	return Ok(new ApiResponse
        //	{
        //		Result = result,
        //		Message = MESSAGE.GET_SUCCESS,
        //		StatusCode = StatusCodes.Status200OK
        //	});
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderDto request)
        {
            var result = await _sender.Send(new UpdateOrderCommand { Id = id, UpdateOrderDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreOrderCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteOrderCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.DeleteOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.RestoreOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToCancelled;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToDone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToServed;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemByOrderId;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/order-items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public OrderItemsController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderItemCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOrderItemIgnoreQueryFilterQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListOrderItemQuery query)
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
            var result = await _sender.Send(new GetOrderItemByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderItemCommand request)
        {
            request.Id = id;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("serving/{id}")]
        public async Task<IActionResult> ServAsync([FromRoute] Guid id, [FromBody] UpdateStatusToServingCommand request)
        {
            request.Id = id;
            await _sender.Send(request);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("done/{id}")]
        public async Task<IActionResult> DoneAsync([FromRoute] Guid id, [FromBody] UpdateStatusToDoneCommand request)
        {
            request.Id = id;
            await _sender.Send(request);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("cancelled/{id}")]
        public async Task<IActionResult> CancelledAsync([FromRoute] Guid id, [FromBody] UpdateStatusToCancelledCommand request)
        {
            request.Id = id;
            await _sender.Send(request);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreOrderItemCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteOrderItemCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("by-order/{orderId}")]
        public async Task<IActionResult> GetByOrderId([FromRoute] Guid orderId)
        {
            var result = await _sender.Send(new GetOrderItemByOrderIdQuery { Id = orderId });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = "Order items retrieved successfully",
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

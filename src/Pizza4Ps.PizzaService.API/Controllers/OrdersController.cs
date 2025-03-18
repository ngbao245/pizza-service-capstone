using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.AddFoodToOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CancelCheckOut;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CheckOutOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.CreateOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.DeleteOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.RestoreOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.UpdateOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrder;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetListOrderIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Queries.GetOrderById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/orders")]
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

        /// <summary>
        /// 0: Order - Khách tới ăn
        /// 1: Workshop - Khách tới tham gia workshop
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand request)
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
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOrderIgnoreQueryFilterQuery query)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListOrderQuery query)
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
            var result = await _sender.Send(new GetOrderByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderCommand request)
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

        //[HttpPut("pending/{id}")]
        //public async Task<IActionResult> PendingAsync([FromRoute] Guid id, [FromBody] UpdateStatusToPendingCommand request)
        //{
        //    request.Id = id;
        //    await _sender.Send(request);

        //    return Ok(new ApiResponse
        //    {
        //        Success = true,
        //        Message = Message.UPDATED_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}

        //[HttpPut("complete/{id}")]
        //public async Task<IActionResult> CompleteAsync([FromRoute] Guid id, [FromBody] UpdateStatusToCompleteCommand request)
        //{
        //    request.Id = id;
        //    await _sender.Send(request);

        //    return Ok(new ApiResponse
        //    {
        //        Success = true,
        //        Message = Message.UPDATED_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}


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

        [HttpPost("add-food-to-order")]
        public async Task<IActionResult> AddFoodToOrderAsync([FromBody] AddFoodToOrderCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("check-out-order/{orderId}")]
        public async Task<IActionResult> CheckOutOrderAsync([FromRoute] Guid orderId)
        {
            await _sender.Send(new CheckOutOrderCommand{
                OrderId = orderId
            });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("cancel-check-out/{orderId}")]
        public async Task<IActionResult> CancelCheckOutAsync([FromRoute] Guid orderId)
        {
            await _sender.Send(new CancelCheckOutCommand
            {
                OrderId = orderId
            });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

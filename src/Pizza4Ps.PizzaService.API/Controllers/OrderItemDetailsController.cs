using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.DeleteOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.RestoreOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/order-item-detail-items")]
	[ApiController]
	public class OrderItemDetailsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OrderItemDetailsController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOrderItemDetailCommand request)
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
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] OrderItemDetailIgnoreQueryFilterQuery query)
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
		public async Task<IActionResult> GetListAsync([FromQuery] GetListOrderItemDetailQuery query)
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
			var result = await _sender.Send(new GetOrderItemDetailByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderItemDetailCommand request)
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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("restore")]
		public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
		{
			await _sender.Send(new RestoreOrderItemDetailCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOrderItemDetailCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}

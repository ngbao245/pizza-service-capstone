using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.DeleteOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.RestoreOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItemStatus;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetOptionItemById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOptionStatus;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/option-items")]
	[ApiController]
	public class OptionItemsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OptionItemsController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

        /// <summary>
        /// Tạo Chi tiết cho từng options
        /// </summary>
        /// <remarks>
        /// - Gia vị món ăn: nhiều cay, ít cay, nhiều ngọt, ít ngọt
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOptionItemCommand request)
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
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOptionItemIgnoreQueryFilterQuery query)
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
		public async Task<IActionResult> GetListAsync([FromQuery] GetListOptionItemQuery query)
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
			var result = await _sender.Send(new GetOptionItemByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOptionItemCommand request)
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
			await _sender.Send(new RestoreOptionItemCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
        [HttpPut("update-status/{optionItemId}")]
        public async Task<IActionResult> UpdateStatusProduct([FromRoute] Guid optionItemId, UpdateOptionItemStatusCommand request)
        {
            request.Id = optionItemId;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOptionItemCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}

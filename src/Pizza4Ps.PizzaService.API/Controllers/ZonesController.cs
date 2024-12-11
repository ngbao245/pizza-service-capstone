using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.DeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.RestoreProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProductById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.CreateZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Zone.Commands.UpdateZone;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ZonesController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public ZonesController(IHttpContextAccessor httpContextAccessor, ISender sender)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateZoneCommand command)
		{
			var result = await _sender.Send(command);
			return Ok(new ApiResponse
			{
				Result = result,
				Message = MESSAGE.CREATED_SUCCESS,
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
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateZoneCommand command)
		{
			if (id != command.Id)
			{
				throw new ValidationException(MESSAGE.ID_URL_ERROR);
			}
			var result = await _sender.Send(command);
			return Ok(new ApiResponse
			{
				Result = result,
				Message = MESSAGE.UPDATED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("restore")]
		public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
		{
			await _sender.Send(new RestoreProductCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = MESSAGE.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteProductCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = MESSAGE.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}

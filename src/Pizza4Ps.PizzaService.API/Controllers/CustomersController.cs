using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.CreateCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.DeleteCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.RestoreCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customer.Commands.UpdateCustomer;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/customers")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public CustomersController(IHttpContextAccessor httpContextAccessor, ISender sender)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
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
		//    var result = await _sender.Send(query);
		//    return Ok(new ApiResponse
		//    {
		//        Result = result,
		//        Message = MESSAGE.GET_SUCCESS,
		//        StatusCode = StatusCodes.Status200OK
		//    });
		//}
		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
		//{
		//    var result = await _sender.Send(new GetProductByIdQuery { Id = id });
		//    return Ok(new ApiResponse
		//    {
		//        Result = result,
		//        Message = MESSAGE.GET_SUCCESS,
		//        StatusCode = StatusCodes.Status200OK
		//    });
		//}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCustomerCommand command)
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
			await _sender.Send(new RestoreCustomerCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = MESSAGE.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteCustomerCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = MESSAGE.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}

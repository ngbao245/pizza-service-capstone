using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionByProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.DeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.RestoreProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProductIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetMenu;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById;

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

		/// <summary>
		/// Tạo món ăn
		/// </summary>
		/// <remarks>
		/// - Thông tin
		/// - CategoryId là id của category
		/// </remarks>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand request)
		{
			var result = await _sender.Send(request);
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

        [HttpGet("menu")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetMenu([FromQuery] GetMenuQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
			{
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListProductIgnoreQueryFilterQuery query)
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
		public async Task<IActionResult> GetListAsync([FromQuery] GetListProductQuery query)
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
		public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id, string includeProperties = "")
		{
			var result = await _sender.Send(new GetProductByIdQuery { Id = id, includeProperties = includeProperties });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand request)
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
			await _sender.Send(new RestoreProductCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteProductCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}


	}
}

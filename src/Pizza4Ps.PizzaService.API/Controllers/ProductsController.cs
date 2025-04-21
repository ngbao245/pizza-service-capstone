using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProductWithCombo;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.DeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.RestoreProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateImageProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProductStatus;
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
        /// - Dữ liệu gửi theo định dạng multipart/form-data.
        /// - ProductOptionModels: Chuỗi JSON chứa danh sách option, theo mẫu sau:
        ///   [
        ///     {
        ///       "name": "Size",
        ///       "description": "Choose your size",
        ///       "productOptionItemModels": [
        ///         { "name": "Small", "additionalPrice": 0 },
        ///         { "name": "Medium", "additionalPrice": 2 },
        ///         { "name": "Large", "additionalPrice": 4 }
        ///       ]
        ///     },
        ///     {
        ///       "name": "Dough",
        ///       "description": "Choose your dough type",
        ///       "productOptionItemModels": [
        ///         { "name": "Thin", "additionalPrice": 0 },
        ///         { "name": "Thick", "additionalPrice": 3 }
        ///       ]
        ///     }
        ///   ]
        ///  Sizes: Chuoi json chứa danh sách size theo product theo mẫu:
        ///   [
        ///     {"name":"Small","price":80000},
        ///     {"name":"Large","price":120000}
        ///   ]
        /// - Lưu ý: Trường "ProductOptionModels" là một chuỗi JSON, FE cần chuyển đổi danh sách option sang JSON string trước khi gửi.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
		public async Task<IActionResult> CreateAsync([FromForm] CreateProductCommand request)
		{
			var result = await _sender.Send(request);
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
        }
        /// <summary>
        /// Tạo món ăn
        /// </summary>
        /// <remarks>
        /// - Dữ liệu gửi theo định dạng multipart/form-data.
        /// - ProductOptionModels: Chuỗi JSON chứa danh sách option, theo mẫu sau:
        ///   [
        ///     {
        ///       "name": "Size",
        ///       "description": "Choose your size",
        ///       "productOptionItemModels": [
        ///         { "name": "Small", "additionalPrice": 0 },
        ///         { "name": "Medium", "additionalPrice": 2 },
        ///         { "name": "Large", "additionalPrice": 4 }
        ///       ]
        ///     },
        ///     {
        ///       "name": "Dough",
        ///       "description": "Choose your dough type",
        ///       "productOptionItemModels": [
        ///         { "name": "Thin", "additionalPrice": 0 },
        ///         { "name": "Thick", "additionalPrice": 3 }
        ///       ]
        ///     }
        ///   ]
        ///  ComboItems: Chuoi json chứa danh sách product theo mẫu:
        ///  [
        ///      { "productId": "11111111-1111-1111-1111-111111111111", "quantity": 1 },
        ///      { "productId": "22222222-2222-2222-2222-222222222222", "quantity": 2 }
        ///  ]
        /// 
        /// 
        /// - Lưu ý: Trường "ProductOptionModels" là một chuỗi JSON, FE cần chuyển đổi danh sách option sang JSON string trước khi gửi.
        /// </remarks>
        /// <returns></returns>
        [HttpPost("create-product-with-combo")]
        public async Task<IActionResult> CreateProductWithSizeAsync([FromForm] CreateProductWithComboCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPut("upload-image")]
        public async Task<IActionResult> UpdateImageProduct([FromForm] UpdateImageProductCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPut("update-status/{productId}")]
        public async Task<IActionResult> UpdateStatusProduct([FromRoute] Guid productId, UpdateProductStatusCommand request)
        {
            request.Id = productId;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
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
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromForm] UpdateProductCommand request)
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

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteManyAsync([FromRoute]Guid id, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteProductCommand
			{
				Ids = new List<Guid> { id},
                isHardDelete = isHardDeleted
            });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}


	}
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.CreateCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.DeleteCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.RestoreCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.HardDeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.SoftDeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Queries.GetProductById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISender _sender;

        public CategoriesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
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
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        throw new ValidationException(MESSAGE.ID_URL_ERROR);
        //    }
        //    var result = await _sender.Send(command);
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = MESSAGE.UPDATED_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreCategoryCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = MESSAGE.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteCategoryCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = MESSAGE.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

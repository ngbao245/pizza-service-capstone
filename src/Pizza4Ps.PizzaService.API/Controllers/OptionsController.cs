using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.DeleteOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.RestoreOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOptionStatus;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetOptionById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateProductStatus;


namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/options")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public OptionsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        /// <summary>
        /// Tạo Options
        /// </summary>
        /// <remarks>
        /// - Tạo options (options là những cái như: gia vị, Món ăn kèm pizza, món ăn kèm mì ý, món ăn kèm...)
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOptionCommand request)
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
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOptionIgnoreQueryFilterQuery query)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListOptionQuery query)
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
            var result = await _sender.Send(new GetOptionByIdQuery { Id = id, includeProperties = includeProperties });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOptionCommand request)
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
            await _sender.Send(new RestoreOptionCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("update-status/{optionId}")]
        public async Task<IActionResult> UpdateStatusProduct([FromRoute] Guid optionId, UpdateOptionStatusCommand request)
        {
            request.Id = optionId;
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
            await _sender.Send(new DeleteOptionCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.CreateBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.DeleteBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.RestoreBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Commands.UpdateBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetBookingById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public BookingsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookingCommand request)
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
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListBookingIgnoreQueryFilterQuery query)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListBookingQuery query)
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
            var result = await _sender.Send(new GetBookingByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBookingCommand request)
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
            await _sender.Send(new RestoreBookingCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteBookingCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.BookingSlots.Commands.CreateBookingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.DeleteProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Commands.DeleteReservationSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Queries.GetReservationSlotList;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/reservation-slot-config")]
    [ApiController]
    public class ReservationSlotsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public ReservationSlotsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        /// <summary>
        ///
        ///  "startTime": "08:00:00",
        ///  "endTime": "18:00:00",
        ///  "capacity": 10
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateReservationSlotCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetReservationSlotListQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManyAsync([FromRoute] Guid id, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteReservationSlotCommand
            {
                Ids = new List<Guid> { id },
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

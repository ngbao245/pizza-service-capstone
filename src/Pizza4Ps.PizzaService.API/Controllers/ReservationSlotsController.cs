using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.BookingSlots.Commands.CreateBookingSlot;

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
    }
}

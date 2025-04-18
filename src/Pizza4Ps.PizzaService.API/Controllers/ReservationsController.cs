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
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.AssignTableReservation;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CancelReservation;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.CheckInReservation;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.ConfirmReservation;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Commands.UnAssignTableReservation;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Reservations.Queries.CheckReservation;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public ReservationsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateReservationCommand request)
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListReservationIgnoreQueryFilterQuery query)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListReservationQuery query)
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetByCustomerCodeAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetReservationByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateReservationCommand request)
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
            await _sender.Send(new RestoreReservationCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteReservationCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckAsync([FromQuery] CheckReservationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);

            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmAsync([FromQuery] ConfirmReservationCommand query, CancellationToken cancellationToken = default)
        {
            await _sender.Send(query, cancellationToken);

            return Ok(new ApiResponse
            {
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpGet("cancel")]
        public async Task<IActionResult> CancelReservation([FromQuery] CancelReservationCommand query, CancellationToken cancellationToken = default)
        {
            await _sender.Send(query, cancellationToken);

            return Ok(new ApiResponse
            {
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost("assign-table-reservation")]
        public async Task<IActionResult> AssignTableAsync([FromBody] AssignTableReservationCommand command)
        {
            var result = await _sender.Send(command);

            if (!result)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = Message.UPDATE_FAILED,
                    StatusCode = 400
                });
            }

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = 200
            });
        }

        [HttpPost("unassign-table-reservation")]
        public async Task<IActionResult> UnAssignTableAsync([FromBody] UnAssignTableReservationCommand command)
        {
            await _sender.Send(command);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = 200
            });
        }
        /// <summary>
        /// Note: Trạng thái bàn: Created -> confirm -> Checkin -> 
        /// Note: Trạng thái bàn: Cancel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("check-in")]
        public async Task<IActionResult> CheckInAsync([FromBody] CheckInReservationCommand command)
        {
            var result = await _sender.Send(command);

            if (!result)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = Message.UPDATE_FAILED,
                    StatusCode = 400
                });
            }

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = 200
            });
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelAsync([FromRoute] Guid id)
        {
            await _sender.Send(new CancelReservationCommand { ReservationId = id });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


    }
}
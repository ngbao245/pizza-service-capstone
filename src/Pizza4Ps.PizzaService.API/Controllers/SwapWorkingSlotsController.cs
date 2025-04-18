using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.DeleteStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.CreateSwapWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.DeleteSwapWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToApproved;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToPendingApprove;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Commands.UpdateStatusToRejected;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetListSwapWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.SwapWorkingSlots.Queries.GetSwapWorkingSlotById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/swap-working-slots")]
    [ApiController]
    public class SwapWorkingSlotsController : ControllerBase
    {
        private readonly ISender _sender;

        public SwapWorkingSlotsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSwapWorkingSlotCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut("pending-approved/{id}")]
        public async Task<IActionResult> PendingApproveAsync([FromRoute] Guid id)
        {
            await _sender.Send(new UpdateStatusToPendingApproveCommand
            {
                Id = id
            });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("approved/{id}")]
        public async Task<IActionResult> ApprovedAsync([FromRoute] Guid id)
        {
            await _sender.Send(new UpdateStatusToApprovedCommand
            {
                Id = id
            });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("rejected/{id}")]
        public async Task<IActionResult> RejectedAsync([FromRoute] Guid id)
        {
            await _sender.Send(new UpdateStatusToRejectedCommand
            {
                Id = id
            });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListSwapWorkingSlotQuery query)
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
            var result = await _sender.Send(new GetSwapWorkingSlotByIdQuery { Id = id });
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
            await _sender.Send(new DeleteSwapWorkingSlotCommand
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

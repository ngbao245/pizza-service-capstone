using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Commands.CreateWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetListWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlots.Queries.GetWorkingSlotById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/working-slots")]
    [ApiController]
    public class WorkingSlotsController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkingSlotsController(ISender sender)
        {
            _sender = sender;
        }

        /// <remarks>
        /// **shiftTime format**:
        /// - "shiftStart": "08:00:00"
        /// - "shiftEnd": "13:00:00"
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWorkingSlotCommand request)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListWorkingSlotQuery query)
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
            var result = await _sender.Send(new GetWorkingSlotByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

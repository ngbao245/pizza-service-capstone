using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.DeleteStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.AutoAssignZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.CreateStaffZoneSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.DeleteStaffZoneSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.RestoreStaffZoneSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateStaffZoneSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Commands.UpdateZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetStaffZoneScheduleById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/staff-zone-schedules")]
    [ApiController]
    public class StaffZoneSchedulesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public StaffZoneSchedulesController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStaffZoneScheduleCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPost("auto-assign")]
        public async Task<IActionResult> AutoAssignZoneAsync([FromBody] AutoAssignZoneCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListStaffZoneScheduleIgnoreQueryFilterQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        /// <remarks>
        /// PartTime
        /// FullTime
        /// </remarks>
        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListStaffZoneScheduleQuery query)
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
            var result = await _sender.Send(new GetStaffZoneScheduleByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("update-zone{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateZoneAsync([FromRoute] Guid id, [FromBody] UpdateZoneCommand request)
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

        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateStaffZoneScheduleCommand request)
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreStaffZoneScheduleCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync([FromRoute] Guid id, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteStaffZoneScheduleCommand
            {
                Ids = new List<Guid> { id },
                isHardDelete = isHardDeleted
            }); return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

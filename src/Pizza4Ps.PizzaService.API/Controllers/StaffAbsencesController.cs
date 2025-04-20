using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.DeleteOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.RestoreOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.CreateStaffAbsence;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.DeleteStaffAbsence;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffAbsences.Commands.RestoreStaffAbsence;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.DeleteStaffZone;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/staff-absences")]
    [ApiController]
    public class StaffAbsencesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public StaffAbsencesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStaffAbsenceCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreStaffAbsenceCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManyAsync([FromRoute] Guid id, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteStaffAbsenceCommand
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

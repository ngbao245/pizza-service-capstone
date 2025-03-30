using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Notifications.Commands.SendStaffCall;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ISender _sender;

        public NotificationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("callstaff/{tableId}")]
        public async Task<IActionResult> CallStaff([FromRoute] Guid tableId)
        {
            await _sender.Send(new SendStaffCallCommand { TableId = tableId });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Called Successfully",
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

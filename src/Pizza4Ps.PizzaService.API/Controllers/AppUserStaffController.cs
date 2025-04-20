using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthStaff.Commands.LoginStaff;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.ChangePassword;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/auth/staff")]
    [ApiController]
    public class AppUserStaffController : ControllerBase
    {
        private readonly ISender _sender;

        public AppUserStaffController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginCustomerAsync([FromBody] LoginStaffCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = "Login successfully",
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangePasswordAsync([FromRoute] Guid id, [FromBody] ChangePasswordStaffCommand request)
        {
            request.StaffId = id;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Password changed successfully.",
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

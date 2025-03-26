using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AdminManagers.Commands.CreateStaffAccount;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISender _sender;

        public AdminController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Staff information, including type and status.
        /// </summary>
        /// <remarks>
        /// **StaffType**:
        /// - Staff
        /// - Manager
        /// - Chef
        /// 
        /// **StaffStatus**:
        /// - PartTime
        /// - FullTime
        /// </remarks>
        [HttpPost("create-staff")]
        public async Task<IActionResult> CreateStaffAsync([FromBody] CreateStaffAccountCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

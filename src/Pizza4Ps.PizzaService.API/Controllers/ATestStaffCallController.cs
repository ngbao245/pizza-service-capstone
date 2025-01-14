using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.Contract.Abstractions.Services;
using Pizza4Ps.PizzaService.Application.DTOs.Bookings;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBooking;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATestStaffCallController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public ATestStaffCallController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _staffService.GetListAsync();
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

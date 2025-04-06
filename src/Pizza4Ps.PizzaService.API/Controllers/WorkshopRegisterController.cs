using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetVoucherById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.AssignTableWorkshopRegister;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CheckInWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CreateWorkshopRegister;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterByCode;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkShopRegisterList;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopList;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/workshop-register")]
    [ApiController]
    public class WorkshopRegisterController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkshopRegisterController(ISender sender)
        {
            _sender = sender;
        }
        //[Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWorkshopRegisterCommand request)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetWorkshopRegisterListQuery query)
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
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id, string includeProperties = "")
        {
            var result = await _sender.Send(new GetWorkshopRegisterByIdQuery { Id = id, includeProperties = includeProperties });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpGet("get-by-code/{code}")]
        public async Task<IActionResult> GetSingleByCodeAsync([FromRoute] string code, string includeProperties = "")
        {
            var result = await _sender.Send(new GetWorkshopRegisterByCodeCommand { Code = code, includeProperties = includeProperties });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPost("check-in-workshop")]
        public async Task<IActionResult> CheckInWorkshopAsync([FromBody] CheckInWorkshopRegisterCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "check-in workshop successfully",
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("assign-table-workshop-register")]
        public async Task<IActionResult> AssignWorkshopRegisterAsync([FromBody] AssignTableWorkshopRegisterCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Assign table successfully",
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

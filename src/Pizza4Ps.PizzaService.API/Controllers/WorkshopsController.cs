using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CancelWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CloseWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CreateWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.OpenWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.ReopenToRegisterWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.UpdateWorkshop;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopList;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkshopsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWorkshopCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPut("cancel-workshop")]
        public async Task<IActionResult> CancelWorkshopAsync([FromBody] CancelWorkshopCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetWorkshopListQuery query)
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
            var result = await _sender.Send(new GetWorkshopByIdQuery { Id = id, includeProperties = includeProperties });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("{workshopId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid workshopId, UpdateWorkshopCommand command)
        {
            command.Id = workshopId;
            await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("close/{workshopId}")]
        public async Task<IActionResult> CloseAsync([FromRoute] Guid workshopId)
        {
            var command = new CloseWorkshopCommand { Id = workshopId };
            await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("open/{workshopId}")]
        public async Task<IActionResult> OpenAsync([FromRoute] Guid workshopId)
        {
            var command = new OpenWorkshopCommand { WorkshopId = workshopId };
            await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("reopen-to-register/{workshopId}")]
        public async Task<IActionResult> ReOpenToRegisterAsync([FromRoute] Guid workshopId, ReopenToRegisterWorkshopCommand command)
        {
            command.WorkshopId = workshopId;
            await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

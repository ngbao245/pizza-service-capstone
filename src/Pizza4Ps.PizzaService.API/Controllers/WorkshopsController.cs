using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CreateWorkshop;
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
    }
}

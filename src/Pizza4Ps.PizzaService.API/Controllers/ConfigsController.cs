using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Commands.UpdateConfig;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Configs.Queries.GetListConfig;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.UpdateCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/configs")]
    [ApiController]
    public class ConfigsController : ControllerBase
    {
        private readonly ISender _sender;

        public ConfigsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateConfigCommand request)
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

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListConfigQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Commands.CreateVoucherType;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetListVoucherType;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetVoucherTypeById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.CreateZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetZoneById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/voucher-types")]
    [ApiController]
    public class VoucherTypesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public VoucherTypesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateVoucherTypeCommand request)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListVoucherTypeQuery query)
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
            var result = await _sender.Send(new GetVoucherTypeByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

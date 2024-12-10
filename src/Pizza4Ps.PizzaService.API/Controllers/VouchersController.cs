using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Product.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/vouchers")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public VouchersController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateVoucherCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = MESSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

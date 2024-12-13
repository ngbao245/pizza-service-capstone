using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.CreateVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.DeleteVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.RestoreVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Commands.UpdateVoucher;

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
        public async Task<IActionResult> CreateAsync([FromBody] CreateVoucherDto request)
        {
            var result = await _sender.Send(new CreateVoucherCommand { CreateVoucherDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateVoucherDto request)
        {
            var result = await _sender.Send(new UpdateVoucherCommand { Id = id, UpdateVoucherDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreVoucherCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteVoucherCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}

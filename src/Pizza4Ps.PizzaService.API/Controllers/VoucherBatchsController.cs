﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Commands.CreateVoucherBatch;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetListVoucherBatch;
using Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetVoucherBatchById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.InvalidVoucherBatch;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/voucher-types")]
    [ApiController]
    public class VoucherBatchsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public VoucherBatchsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateVoucherBatchCommand request)
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
        public async Task<IActionResult> GetListAsync([FromQuery] GetListVoucherBatchQuery query)
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
            var result = await _sender.Send(new GetVoucherBatchByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
        [HttpPut("invalid-voucherbatch/{voucherBatchId}")]
        [HttpPut]
        public async Task<IActionResult> InvalidVoucherbatchAsync([FromRoute]Guid voucherBatchId , [FromBody] InvalidVoucherBatchCommand request)
        {
            request.VoucherBatchId = voucherBatchId;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

    }
}

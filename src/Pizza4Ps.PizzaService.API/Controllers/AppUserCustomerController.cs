﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.IsPhoneOtp;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.RegisterCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyEmail;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.SendCodeVerifyPhone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.VerifyEmail;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthStaff.Commands.LoginStaff;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/auth/customer")]
    [ApiController]
    public class AppUserCustomerController : ControllerBase
    {
        private readonly ISender _sender;

        public AppUserCustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAppUserCustomerAsync([FromBody] RegisterCustomerCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("send-verify-code")]
        public async Task<IActionResult> SendVerifyCodeAsync([FromBody] SendCodeVerifyEmailCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmailAsync([FromBody] VerifyEmailCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("send-otp-phone")]
        public async Task<IActionResult> SendOtpPhoneAsync([FromBody] SendOtpVerifyPhoneCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("is-phone-otp")]
        public async Task<IActionResult> IsPhoneOtpAsync([FromBody] IsPhoneOtpCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Success = true,
                Message = "Mã Otp trùng khớp",
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginCustomerAsync([FromBody] LoginCustomerCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = "Login successfully",
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}

//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Pizza4Ps.PizzaService.API.Constants;
//using Pizza4Ps.PizzaService.API.Models;
//using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer;
//using Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.CreateCustomer;

//namespace Pizza4Ps.PizzaService.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly ISender _sender;

//        public AuthController(IHttpContextAccessor httpContextAccessor, ISender sender)
//        {
//            _httpContextAccessor = httpContextAccessor;
//            _sender = sender;
//        }

//        [HttpPost("customer/login")]
//        public async Task<IActionResult> LoginCustomerAsync([FromBody] LoginCustomerCommand request)
//        {
//            var result = await _sender.Send(request);
//            return Ok(new ApiResponse
//            {
//                Result = result,
//                Message = Message.CREATED_SUCCESS,
//                StatusCode = StatusCodes.Status201Created
//            });
//        }
//    }
//}

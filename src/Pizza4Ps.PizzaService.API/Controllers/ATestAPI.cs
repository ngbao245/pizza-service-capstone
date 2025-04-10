using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.Application.Helpers;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATestAPI : ControllerBase
    {
        private readonly EmailService _emailService;

        public ATestAPI(EmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send-workshop-confirmation")]
        public async Task<IActionResult> SendWorkshopEmail([FromBody] EmailRequest request)
        {
            if (string.IsNullOrEmpty(request.CustomerEmail) || string.IsNullOrEmpty(request.WorkshopName))
            {
                return BadRequest("Thiếu thông tin đăng ký.");
            }

            string registrationCode = RegistrationCodeGenerator.GenerateCode(8);
            await _emailService.SendWorkshopRegisterEmail(request.CustomerEmail, request.CustomerName, request.WorkshopName, registrationCode);

            return Ok(new { message = "Email đã gửi thành công!", registrationCode });
        }
        public class EmailRequest
        {
            public string CustomerEmail { get; set; }
            public string CustomerName { get; set; }
            public string WorkshopName { get; set; }
        }
    }
}

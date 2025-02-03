using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/health")]
    [ApiController]
    public class HealthControler : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetTestAsync()
        {
            var obj = new { id = 1, Description = "test" };
            return Ok(JsonSerializer.Serialize(obj));
        }

    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroService2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        public ApiController()
        {
        }

        [HttpPost("[action]")]
        public IActionResult Webhook([FromBody] string message)
        {
            if(message == null || !message.Contains("{{firstname}}") || !message.Contains("{{lastname}}"))
            {
                return BadRequest("Invalid message");
            }
            var result = message.Replace("{{firstname}}", "Stefan");
            result = result.Replace("{{lastname}}", "Riedmann");
            return Ok(result);
        }
    }
}
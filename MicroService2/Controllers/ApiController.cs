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

        [HttpGet("[action]")]
        public string Test()
        {
            return "Welcome Microservice2";
        }
    }
}
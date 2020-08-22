using System.Threading.Tasks;
using MicroService1.Models;
using MicroService1.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly DatabaseService dbService;
        private readonly Ms2Service ms2Service;

        public ApiController(DatabaseService dbService, Ms2Service ms2Service)
        {
            this.dbService = dbService;
            this.ms2Service = ms2Service;
        }

        [HttpPost("[action]")]
        public void PostConfiguration([FromBody] Ms2Configuration config)
        {
            this.dbService.Set(config);
        }
        

        [HttpPost("[action]")]
        public async Task<string> PostMessage([FromBody] string message)
        {
            var ms2Config = this.dbService.Get();
            var response = await ms2Service.SendMessage(ms2Config, message);
            return response;
        }
    }
}
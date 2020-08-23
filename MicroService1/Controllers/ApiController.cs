using System;
using System.Threading.Tasks;
using MicroService1.Models;
using MicroService1.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("[action]")]
        public Ms2Configuration GetConfiguration()
        {
            var result = this.dbService.Get();
            return result;
        }

        [HttpPost("[action]")]
        public void PostConfiguration([FromBody] Ms2Configuration config)
        {
            this.dbService.Set(config);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostMessage([FromBody] string message)
        {
            var ms2Config = this.dbService.Get();
            try
            {
                var response = await ms2Service.SendMessage(ms2Config, "Hello, {{firstname}} {{lastname}}. Thanks for applying at BOTfriends.");
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch(UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch(ApplicationException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return BadRequest("Unexpected");
            }
        }
    }
}
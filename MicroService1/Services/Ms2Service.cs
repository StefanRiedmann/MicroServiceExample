using System;
using System.Net.Http;
using System.Threading.Tasks;
using MicroService1.Models;

namespace MicroService1.Services
{
    public class Ms2Service
    {
        public Ms2Service()
        {}

        public async Task<string> SendMessage(Ms2Configuration config, string message)
        {
            
            using(var client = new HttpClient())
            {
                var response = await client.PostAsync(config.Url, new StringContent(message));

            }
            throw new NotImplementedException();
        }
    }
}
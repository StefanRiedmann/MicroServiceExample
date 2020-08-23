using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MicroService1.Models;
using Newtonsoft.Json;

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
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(message));
                    content.Headers.Clear();
                    content.Headers.Add("x-api-key", config.Secret);
                    content.Headers.Add("Content-Type", "application/json");
                    var response = await client.PostAsync(config.Url, content);
                    
                    if(response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    else if(response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException(response.ReasonPhrase);
                    }
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer;
                }
                catch(UnauthorizedAccessException)
                {
                    throw;
                }
                catch(ApplicationException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Error calling webhook", ex);
                }
            }
        }
    }
}
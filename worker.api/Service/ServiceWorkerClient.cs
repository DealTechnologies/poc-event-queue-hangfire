using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace worker.api.Service
{
    public class ServiceWorkerClient : IWorkerClient
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<dynamic> Function1Async(object parameters)
        {
            client.BaseAddress = new Uri("http://localhost:7071");
            client.Timeout = TimeSpan.FromMinutes(30);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (client)
            {
                var json = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await client.PostAsync("api/Function1", content);
                var ret = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<dynamic>(ret);
            }
        }

        public async Task<dynamic> Function2Async(object parameters)
        {
            client.BaseAddress = new Uri("http://localhost:7071");
            client.Timeout = TimeSpan.FromMinutes(30);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (client)
            {
                var json = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await client.PostAsync("api/Function2", content);
                var ret = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<dynamic>(ret);
            }
        }
    }

    public interface IWorkerClient
    {
        Task<dynamic> Function1Async(object parameters);
        Task<dynamic> Function2Async(object parameters);
    }
}
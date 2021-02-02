using MotorqService.Models;
using MotorqService.Service;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MotorqClient
{
    public class MotorqApiClient
    {
        private IMotorqService _service;
        public MotorqApiClient(HttpClient client)
        {
            _service = new MotorqService.Service.MotorqService(client);
        }

        public Task<string> GetTest()
        {
            // return client.GetFromJsonAsync<Home>($"/homes/{_guidy}");
            return _service.GetDriver("/v3/drivers/testtest");
        }


    }
}

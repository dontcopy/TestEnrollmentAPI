using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MotorqService.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MotorqService.Service
{
    public class MotorqService : IMotorqService
    {
        private HttpClient _client = null;
        private readonly string _baseUrl= "https://mfleetdevapi.motorq.co";

        public MotorqService(HttpClient client = null)
        {
            if (client == null)
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
            }
            else
                _client = client;
        }

        public async Task<TokenResponseModel> GetAccessToken(TokenRequestModel request)
        {
            using var response = await _client.PostAsJsonAsync("v3/oauth/token", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<TokenResponseModel>();

            return result;

        }

        public Task<GetEnrollmentResponseModel> GetEnrollments(AuthRequest<GetEnrollmentRequestModel> request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetDriver(string path)
        {
            var driver = string.Empty;
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                driver = await response.Content.ReadAsStringAsync();
            }
            return driver;
        }

        /*public static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }*/
    }
}

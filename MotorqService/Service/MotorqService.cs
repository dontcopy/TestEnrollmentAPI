using MotorqService.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MotorqService.Service
{
    public class MotorqService : IMotorqService
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl= "https://mfleetdevapi.motorq.co";
        public MotorqService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TokenResponseModel> GetAccessToken(TokenRequestModel request)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://mfleetdevapi.motorq.co")
            };
            using var response = await httpClient.PostAsJsonAsync("v3/oauth/token", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<TokenResponseModel>();

            return result;

        }

        public Task<GetEnrollmentResponseModel> GetEnrollments(AuthRequest<GetEnrollmentRequestModel> request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDriver(string path)
        {
            throw new NotImplementedException();
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

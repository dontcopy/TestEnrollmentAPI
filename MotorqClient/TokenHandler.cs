using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MotorqClient
{
    public class TokenHandler : DelegatingHandler
    {
        private string _originalAuthToken = String.Empty;
        private MotorqService.Service.MotorqService _service;
        public TokenHandler()/*: this(new HttpClientHandler())*/
        {
            _service = new MotorqService.Service.MotorqService();
        }

      /*  public TokenHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }*/

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request= await CheckForAuthTokenAsync(request);


            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<HttpRequestMessage> CheckForAuthTokenAsync(HttpRequestMessage request)
        {
        
            if(!request.Headers.Contains("Bearer"))
            {
                var response = await _service.GetAccessToken(
                               new MotorqService.Models.TokenRequestModel
                               {
                                   audience = request.Headers.GetValues("audience").FirstOrDefault(),
                                   clientId = request.Headers.GetValues("clientId").FirstOrDefault(),
                                   clientSecret = request.Headers.GetValues("clientSecret").FirstOrDefault(),
                                   grantType = request.Headers.GetValues("grantType").FirstOrDefault()
                               });
                request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", response.accessToken);
            }
            /*
             expiration/cache
             */
            return request;
        }
    }
}
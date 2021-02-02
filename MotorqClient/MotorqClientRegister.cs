using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MotorqClient
{
    public static class MotorqClientRegister
    {
        public static IServiceCollection AddApiClient(
            this IServiceCollection services,
            Action<HttpClient> clientConfiguration)
        {
            services.AddTransient<HttpContextMiddleware>();
            services.AddTransient<TokenHandler>();
            services.AddHttpClient<MotorqApiClient>(clientConfiguration)
                  .AddHttpMessageHandler<TokenHandler>()
                .AddHttpMessageHandler<HttpContextMiddleware>();

            return services;
        }
    }
}

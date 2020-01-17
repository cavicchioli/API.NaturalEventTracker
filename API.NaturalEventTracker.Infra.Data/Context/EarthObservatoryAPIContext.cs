using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace API.NaturalEventTracker.Infra.Data.Context
{
    public static class EarthObservatoryAPIContext
    {
        public static IServiceCollection AddEarthObservatoryAPIContext(
           this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient("eonetapi", c =>
            {
                c.BaseAddress = new Uri("https://eonet.gsfc.nasa.gov/api/v3/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "NaturalEventTracker");
            })
             .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }));

            return services;
        }
    }
}

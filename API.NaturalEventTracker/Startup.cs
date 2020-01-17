using API.NaturalEventTracker.Infra.CrossCutting.IoC;
using API.NaturalEventTracker.Infra.Data.Context;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace API.NaturalEventTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("API.NaturalEventTracker.Application");
            services.AddMvc();
            services.AddBootStrapperIoC();
            services.AddMediatR(assembly);
            services.AddEarthObservatoryAPIContext();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Earth Observatory Natural Event Tracker (EONET)",
                    Description = "EONET is a repository of metadata about natural events accessible via API.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Victor Cavichiolli",
                        Email = "xvictorprado@gmail.com",
                        Url = new Uri("https://github.com/cavicchioli")
                    },
                });

                c.EnableAnnotations();

            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Earth Observatory Natural Event Tracker (EONET) v1");
            });
        }
    }
}

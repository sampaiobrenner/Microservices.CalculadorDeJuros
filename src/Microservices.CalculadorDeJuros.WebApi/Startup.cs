using Microservices.CalculadorDeJuros.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;

namespace Microservices.CalculadorDeJuros.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) => _config = config;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            // Habilita o middleware para servir o Swagger gerado como um endpoint JSON
            app.UseSwagger();

            // Habilita o middleware para servir o swagger-ui, especificando o endpoint Swagger JSON
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservices.CalculadorDeJuros.WebApi - v1"));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            // Registra o gerador Swagger definindo um ou mais documentos Swagger
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Microservices.CalculadorDeJuros.WebApi",
                Version = "v1"
            }));

            services.AddHttpClient("taxaDeJurosV1", c => c.BaseAddress = new Uri(_config["UrlApiTaxaDeJurosV1"])).AddPolicyHandler(GetRetryPolicy());

            IocServices.Register(services);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
            HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}
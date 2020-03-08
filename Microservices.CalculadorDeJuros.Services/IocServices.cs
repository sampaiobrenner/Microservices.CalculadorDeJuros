using Microservices.CalculadorDeJuros.Services.Clients;
using Microservices.CalculadorDeJuros.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.CalculadorDeJuros.Services
{
    public static class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosClient, TaxaDeJurosClient>();
            services.AddScoped<ICalculadorDeJurosServices, CalculadorDeJurosServices>();
        }
    }
}
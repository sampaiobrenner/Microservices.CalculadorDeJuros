using Microservices.CalculadorDeJuros.Domain;
using Microservices.CalculadorDeJuros.Domain.Builders;
using Microservices.CalculadorDeJuros.Services.Clients;
using System.Threading.Tasks;

namespace Microservices.CalculadorDeJuros.Services.Services
{
    public class CalculadorDeJurosServices : ICalculadorDeJurosServices
    {
        private readonly ITaxaDeJurosClient _client;

        public CalculadorDeJurosServices(ITaxaDeJurosClient client) => _client = client;

        public async Task<CalculadoraDeJuros> GetAsync(decimal valorInicial, int meses)
        {
            var taxaDeJurosDto = await _client.GetAsync();

            var calculadoraDeJuros = new CalculadoraDeJurosBuilder()
                .WithMeses(meses)
                .WithTaxaDeJuros(taxaDeJurosDto.Valor)
                .WithValorInicial(valorInicial)
                .Build();

            return calculadoraDeJuros;
        }
    }
}
using Microservices.CalculadorDeJuros.Entities;
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
            var taxaDeJuros = await _client.GetAsync();

            return new CalculadoraDeJuros(valorInicial, meses, taxaDeJuros.Valor);
        }
    }
}
using Microservices.CalculadorDeJuros.Contratos;
using System.Threading.Tasks;

namespace Microservices.CalculadorDeJuros.Services.Clients
{
    public interface ITaxaDeJurosClient
    {
        Task<TaxaDeJurosDto> GetAsync();
    }
}
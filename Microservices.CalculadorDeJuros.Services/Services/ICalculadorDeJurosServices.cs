using Microservices.CalculadorDeJuros.Domain;
using System.Threading.Tasks;

namespace Microservices.CalculadorDeJuros.Services.Services
{
    public interface ICalculadorDeJurosServices
    {
        Task<CalculadoraDeJuros> GetAsync(decimal valorInicial, int meses);
    }
}
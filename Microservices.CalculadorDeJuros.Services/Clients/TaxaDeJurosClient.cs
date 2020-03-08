using Microservices.CalculadorDeJuros.Contratos;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.CalculadorDeJuros.Services.Clients
{
    public class TaxaDeJurosClient : ITaxaDeJurosClient
    {
        private const string Endpoint = "taxaJuros";
        private readonly IHttpClientFactory _httpClientFactory;

        public TaxaDeJurosClient(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task<TaxaDeJurosDto> GetAsync()
        {
            var responseMessage = await GetClient().GetAsync(Endpoint);

            return responseMessage.IsSuccessStatusCode
                ? await OnSuccess(responseMessage)
                : OnError(responseMessage);
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient("taxaDeJurosV1");

        private TaxaDeJurosDto OnError(HttpResponseMessage response)
        {
            var dto = new TaxaDeJurosDto();
            dto.AddError(response.ToString());
            return dto;
        }

        private async Task<TaxaDeJurosDto> OnSuccess(HttpResponseMessage response)
        {
            var resultAsString = await response.Content.ReadAsStringAsync();
            return new TaxaDeJurosDto
            {
                Valor = decimal.Parse(resultAsString, CultureInfo.InvariantCulture)
            };
        }
    }
}
using Microservices.CalculadorDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Microservices.CalculadorDeJuros.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ShowMeTheCodeV1Controller : BaseController
    {
        private const string UrlContainerCalculadorDeJuros = "https://hub.docker.com/r/sampaiobrenner/microservices-calculador-de-juros";
        private const string UrlContainerTaxaDeJuros = "https://hub.docker.com/r/sampaiobrenner/microservices-taxa-de-juros";
        private const string UrlMsCalculadorDeJuros = "https://github.com/sampaiobrenner/Microservices.CalculadorDeJuros";
        private const string UrlMsCalculadorDeJurosContratos = "https://github.com/sampaiobrenner/Microservices.CalculadorDeJuros.Contratos";
        private const string UrlMsTaxaDeJuros = "https://github.com/sampaiobrenner/Microservices.TaxaDeJuros";

        [HttpGet("showMeTheCode")]
        public IActionResult Get()
        {
            var str = new StringBuilder();
            str.Append(UrlMsCalculadorDeJuros + Environment.NewLine);
            str.Append(UrlMsTaxaDeJuros + Environment.NewLine);
            str.Append(UrlMsCalculadorDeJurosContratos + Environment.NewLine);
            str.Append(UrlContainerCalculadorDeJuros + Environment.NewLine);
            str.Append(UrlContainerTaxaDeJuros);

            return Ok(str.ToString());
        }
    }
}
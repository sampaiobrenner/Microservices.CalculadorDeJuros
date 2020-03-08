using Microservices.CalculadorDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace Microservices.CalculadorDeJuros.WebApi.Controllers.v1
{
    [Route("v{version:apiVersion}/showMeTheCode")]
    public class ShowMeTheCodeV1Controller : BaseController
    {
        private const string UrlMsCalculadorDeJuros = "https://github.com/sampaiobrenner/Microservices.CalculadorDeJuros";
        private const string UrlMsCalculadorDeJurosContratos = "https://github.com/sampaiobrenner/Microservices.CalculadorDeJuros.Contratos";
        private const string UrlMsTaxaDeJuros = "https://github.com/sampaiobrenner/Microservices.TaxaDeJuros";

        [HttpGet]
        public IActionResult Get()
        {
            var str = new StringBuilder();
            str.Append(UrlMsCalculadorDeJuros + Environment.NewLine);
            str.Append(UrlMsTaxaDeJuros + Environment.NewLine);
            str.Append(UrlMsCalculadorDeJurosContratos);

            return Ok(str.ToString());
        }
    }
}
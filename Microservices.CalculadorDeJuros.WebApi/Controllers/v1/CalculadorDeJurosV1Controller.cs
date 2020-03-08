﻿using Microservices.CalculadorDeJuros.Services.Services;
using Microservices.CalculadorDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Microservices.CalculadorDeJuros.WebApi.Controllers.v1
{
    [Route("v{version:apiVersion}/calculaJuros")]
    public class CalculadorDeJurosV1Controller : BaseController
    {
        private readonly ICalculadorDeJurosServices _calculadorDeJurosServices;

        public CalculadorDeJurosV1Controller(ICalculadorDeJurosServices calculadorDeJurosServices) =>
            _calculadorDeJurosServices = calculadorDeJurosServices;

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] decimal valorInicial, int meses)
        {
            try
            {
                var calculoDeJurosDto = await _calculadorDeJurosServices.GetAsync(valorInicial, meses);

                if (calculoDeJurosDto.IsValid)
                    return Ok(calculoDeJurosDto.Resultado);

                return BadRequest(calculoDeJurosDto.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno. Mensagem de erro: {ex.Message}");
            }
        }
    }
}
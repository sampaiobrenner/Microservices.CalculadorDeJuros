using Microservices.CalculadorDeJuros.Domain.Builders;
using System;
using Xunit;

namespace Microservices.CalculadorDeJuros.Domain.UnitTests
{
    public class CalculadorDeJurosUnitTests
    {
        [Theory]
        [InlineData(0, 1.99, 0.01)]
        [InlineData(1, 0, 0.01)]
        [InlineData(1, 1.99, 0)]
        public void RealizarCalculoDeJurosComParametrosInvalidos(int meses, decimal valorInicial, decimal taxaDeJuros)
        {
            var calculadora = new CalculadoraDeJurosBuilder()
                .WithMeses(meses)
                .WithValorInicial(valorInicial)
                .WithTaxaDeJuros(taxaDeJuros)
                .Build();

            Assert.Equal(calculadora.CalcularJuros(), default);
            Assert.False(calculadora.IsValid);
        }

        [Theory]
        [InlineData(1, 2, 0.01)]
        [InlineData(12, 100.50, 1)]
        public void RealizarCalculoDeJurosComParametrosValidos(int meses, decimal valorInicial, decimal taxaDeJuros)
        {
            var calculadora = new CalculadoraDeJurosBuilder()
                .WithMeses(meses)
                .WithValorInicial(valorInicial)
                .WithTaxaDeJuros(taxaDeJuros)
                .Build();

            var pow = Math.Pow((double)(1 + taxaDeJuros), meses);
            var result = valorInicial * (decimal)pow;
            var resultado = decimal.Parse(result.ToString("##.00"));

            Assert.Equal(meses, calculadora.Meses);
            Assert.Equal(valorInicial, calculadora.ValorInicial);
            Assert.Equal(taxaDeJuros, calculadora.TaxaDeJuros);
            Assert.Equal(calculadora.CalcularJuros(), resultado);
            Assert.True(calculadora.IsValid);
        }
    }
}
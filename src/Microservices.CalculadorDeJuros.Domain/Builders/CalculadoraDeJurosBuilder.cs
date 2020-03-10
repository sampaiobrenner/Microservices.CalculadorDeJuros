using Microservices.CalculadorDeJuros.Domain.Base;

namespace Microservices.CalculadorDeJuros.Domain.Builders
{
    public class CalculadoraDeJurosBuilder : BuilderBase<CalculadoraDeJuros>
    {
        private int Meses { get; set; }

        private decimal TaxaDeJuros { get; set; }

        private decimal ValorInicial { get; set; }

        public override CalculadoraDeJuros Build() => CalculadoraDeJuros.CreateInstance(ValorInicial, Meses, TaxaDeJuros);

        public CalculadoraDeJurosBuilder WithMeses(int meses)
        {
            Meses = meses;
            return this;
        }

        public CalculadoraDeJurosBuilder WithTaxaDeJuros(decimal taxaDeJuros)
        {
            TaxaDeJuros = taxaDeJuros;
            return this;
        }

        public CalculadoraDeJurosBuilder WithValorInicial(decimal valorInicial)
        {
            ValorInicial = valorInicial;
            return this;
        }
    }
}
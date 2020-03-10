using Microservices.CalculadorDeJuros.Domain.Base;
using System;

namespace Microservices.CalculadorDeJuros.Domain
{
    public class CalculadoraDeJuros : ErrorBase
    {
        private CalculadoraDeJuros(decimal valorInicial, int meses, decimal taxaDeJuros)
        {
            SetValorInicial(valorInicial);
            SetMeses(meses);
            SetTaxaDeJuros(taxaDeJuros);
        }

        public int Meses { get; private set; }

        public decimal TaxaDeJuros { get; private set; }

        public decimal ValorInicial { get; private set; }

        public decimal CalcularJuros()
        {
            if (!IsValid) return default;

            var pow = Math.Pow((double)(1 + TaxaDeJuros), Meses);
            var result = ValorInicial * (decimal)pow;
            return decimal.Parse(result.ToString("##.00"));
        }

        internal static CalculadoraDeJuros CreateInstance(decimal valorInicial, int meses, decimal taxaDeJuros) =>
                    new CalculadoraDeJuros(valorInicial, meses, taxaDeJuros);

        private void SetMeses(int meses)
        {
            if (default == meses)
            {
                AddError("A quantidade de meses deve ser maior que zero.");
                return;
            }
            Meses = meses;
        }

        private void SetTaxaDeJuros(decimal taxaDeJuros)
        {
            if (default == taxaDeJuros)
            {
                AddError("A taxa de juros deve ser maior que zero.");
                return;
            }
            TaxaDeJuros = taxaDeJuros;
        }

        private void SetValorInicial(decimal valorInicial)
        {
            if (default == valorInicial)
            {
                AddError("O valor inicial deve ser maior que zero.");
                return;
            }
            ValorInicial = valorInicial;
        }
    }
}
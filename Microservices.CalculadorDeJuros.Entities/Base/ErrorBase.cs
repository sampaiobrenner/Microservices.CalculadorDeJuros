using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Microservices.CalculadorDeJuros.Entities.Base
{
    public abstract class ErrorBase
    {
        protected ErrorBase() => Errors = new List<string>();

        [NotMapped]
        public ICollection<string> Errors { get; protected set; }

        [NotMapped]
        public bool IsValid => Errors.Count == 0;

        public void AddError(string erro)
        {
            if (!Errors.Contains(erro))
                Errors.Add(erro);
        }

        public void AddError(ICollection<string> erros) => erros.ToList().ForEach(AddError);
    }
}
namespace Microservices.CalculadorDeJuros.Domain.Base
{
    public abstract class BuilderBase<TEntity> where TEntity : class
    {
        public abstract TEntity Build();
    }
}
namespace Broadcaster.Application.Services.Implementations.FactoryMethodDomain
{
    public abstract class DomainCreator<TEntity, TReturn> : IFactory<TEntity, TReturn>
       where TEntity : class where TReturn : class
    {
        public abstract TReturn? FactoryMethod(TEntity entity);
    }
}

namespace Broadcaster.Application.Services.Implementations.FactoryMethodDomain
{
    public interface IFactory<TEntity, TReturn>
       where TEntity : class where TReturn : class
    {
        TReturn? FactoryMethod(TEntity entity);
    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.FactoryMethodDomain
{
    public abstract class DomainCreator<TEntity>: IFactory<TEntity>
        where TEntity : Entity<Guid>
    {
        public abstract TEntity? FactoryMethod(string[] vars);
    }
}

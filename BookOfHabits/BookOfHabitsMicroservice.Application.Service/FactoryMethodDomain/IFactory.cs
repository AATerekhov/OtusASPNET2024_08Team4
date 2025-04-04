using BookOfHabitsMicroservice.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.FactoryMethodDomain
{
    public interface IFactory<TEntity> 
        where TEntity : Entity<Guid>
    {
        TEntity? FactoryMethod(string[] vars);
    }
}

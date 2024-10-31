using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class PersonRepository : EFRepository<Person, Guid>, IRepository<Person, Guid>
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

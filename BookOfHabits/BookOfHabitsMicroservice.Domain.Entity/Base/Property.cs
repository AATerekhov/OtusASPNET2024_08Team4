using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Base
{
    public class Property(Guid id, string nameType):Entity<Guid>(id)
    {
        public string NameType => nameType;
    }
}

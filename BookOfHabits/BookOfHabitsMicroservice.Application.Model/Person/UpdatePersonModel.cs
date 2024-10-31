using BookOfHabitsMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Person
{
    public class UpdatePersonModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}

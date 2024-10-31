using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Person
{
    public class PersonModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required IEnumerable<HabitModel> SuggestedHabits { get; init; }

    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using System.Diagnostics;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Person : Entity<Guid>
    {
        private readonly ICollection<Habit> _habits = [];
        private readonly ICollection<Room> _rooms = [];
        public IReadOnlyCollection<Habit> AttendedLessons => [.._habits];
        public IReadOnlyCollection<Room> RecievedGrades => [.._rooms];
        public PersonName Name { get; private set; }
        public Person(Guid id, PersonName name) : base(id)
        {
            Name = name;
        }
    }
}

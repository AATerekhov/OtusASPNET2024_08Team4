using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using System.Diagnostics;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Person : Entity<Guid>
    {
        private readonly ICollection<Habit> _habits = [];
        private readonly ICollection<Room> _rooms = [];
        public IReadOnlyCollection<Habit> SuggestedHabits => [.. _habits];
        public IReadOnlyCollection<Room> RoomManager => [.. _rooms];
        public PersonName Name { get; }
        public Person(Guid id, PersonName name) : base(id)
        {
            Name = name;
        }
        public Person(PersonName name)
            :this(Guid.NewGuid(), name)
        {
                
        }
        protected Person(Guid id):base(id)
        {
                
        }
    }
}

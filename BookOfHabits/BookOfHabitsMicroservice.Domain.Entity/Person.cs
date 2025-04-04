using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Person : Entity<Guid>
    {
        private readonly ICollection<Habit> _habits = [];
        private readonly ICollection<Room> _rooms = [];
        public IReadOnlyCollection<Habit> SuggestedHabits => [.. _habits];
        public IReadOnlyCollection<Room> RoomManager => [.. _rooms];
        public PersonName Name { get; private set; }
        public Guid OwnerId { get; private set; }
        public Person(Guid id, PersonName name, Guid ownerId) : base(id)
        {
            Name = name;
            OwnerId = ownerId;
        }
        public Person(PersonName name, Guid ownerId)
            :this(Guid.NewGuid(), name, ownerId)
        {
                
        }
        protected Person():base(Guid.NewGuid())
        {

        }
        internal void AdministerRoom(Room room)
        {
            if (!_rooms.Contains(room))
                _rooms.Add(room);
        }
        internal void GetHabit(Habit habit)
        {
            if (!_habits.Contains(habit))
                _habits.Add(habit);
        }
        public void SetName(string name) => Name = new PersonName(name);
    }
}

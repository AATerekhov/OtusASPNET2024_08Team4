using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Exceptions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Room : Entity<Guid>
    {
        private readonly ICollection<Habit> _habits = [];
        private readonly ICollection<Coins> _bags = [];
        public IReadOnlyCollection<Habit> SuggestedHabits => _habits.Where(habit => !habit.IsUsed).ToList().AsReadOnly();
        public IReadOnlyCollection<Coins> AssignedCoins => [.. _bags];
        public Person Manager { get; }
        public RoomName Name { get; private set; }
        public DateTime CreateDate { get; }
        public DateTime UpdateDate { get; private set; }
        public bool IsActive { get; private set; }
        public Room(Guid id, Person manager, RoomName name, DateTime createDate, DateTime updateDate)
            :base(id)
        {
            Name = name;
            CreateDate = createDate;
            IsActive = true;
            UpdateDate = updateDate; 
            Manager = manager;
            manager.AdministerRoom(this);
        }
        public Room(Person manager, RoomName name, DateTime createDate, DateTime updateDate)
            :this(Guid.NewGuid(), manager, name, createDate, updateDate)
        {
                
        }
        protected Room() : base(Guid.NewGuid())
        {

        }
        internal void GetHabit(Habit habit)
        {
            if (_habits.Contains(habit))
                throw new DoubleHabitRoomException(this, habit);
            _habits.Add(habit);
            UpdateDate = DateTime.Now.ToUniversalTime();
        }
        public void GetCoins(Coins coins)
        {
            if (_habits.Contains(coins.Habit) is false)
                throw new InvalidOperationException($"The habit {coins.Habit.Name} is not in the room {Name}");
            if (_bags.FirstOrDefault(c => c.Habit.Equals(coins.Habit)) is not null)
                throw new DoubleCoinsRoomException(this, coins);
            _bags.Add(coins);
        }
        public void SetName(string name) => Name = new RoomName(name);      
        public void SetActiveStatus(bool activeStatus) => IsActive = activeStatus;      
    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Habit : Entity<Guid>
    {
        public HabitName Name { get; private set; }
        public string Description { get; private set; }
        public Card Card { get; }
        public Room Room { get; }
        public Coins? Coins { get; private set; }
        public bool IsUsed { get; private set; }
        public HabitOptions Options { get; }
        public Delay Delay { get; }
        public TimeResetInterval TimeResetInterval { get; }
        public Repetition Repetition { get; }
        public Habit(Guid id, HabitName name, Card card, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition)
            : base(id)
        {
            Name = name;
            Card = card;
            Room = room;
            Options = options;
            Delay = delay;
            TimeResetInterval = timeResetInterval;
            Repetition = repetition;
            IsUsed = false;
        }
        public Habit(HabitName name, Card сard, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition)
            : this(Guid.NewGuid(), name, сard, room, options, delay, timeResetInterval, repetition)
        {

        }
        protected Habit() : base(Guid.NewGuid())
        {

        }
        internal void UseInTheCoins(Coins coins) 
        {        
            Coins = coins;
            IsUsed = true;
        }
    }
}

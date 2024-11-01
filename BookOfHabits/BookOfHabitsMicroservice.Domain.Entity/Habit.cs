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
        public Person Owner { get; }
        public Card? Card { get; private set; }
        public Room Room { get; }
        public Coins? Coins { get; private set; }
        public bool IsUsed { get; private set; }
        public HabitOptions Options { get; private set; }
        public Delay Delay { get; }
        public TimeResetInterval TimeResetInterval { get; }
        public Repetition Repetition { get; }
        public Habit(Guid id, HabitName name, string description, Person owner, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition, Card? card = null)
            : base(id)
        {
            Name = name;
            Description = description;
            Owner = owner;
            Room = room;
            if (card is not null)
                Card = card;
            Options = options;
            Delay = delay;
            TimeResetInterval = timeResetInterval;
            Repetition = repetition;
            IsUsed = false;
            Room.GetHabit(this);

        }
        public Habit(HabitName name, string description, Person owner, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition, Card? card = null)
            : this(Guid.NewGuid(), name, description,owner, room, options, delay, timeResetInterval, repetition, card)
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
        public void GetCard(Card card) 
        {
            if (Card is not null)
                throw new InvalidOperationException($"The card has already been assigned habit {Name}");
            var newCard = card.DeepCopy();
            newCard.Close();
            Card = newCard;
        }
        public void SetName(string name) => Name = new HabitName(name);
        public void SetDescription(string description) => Description = description;
        public void SetOptions(HabitOptions options) => Options = options;
    }
}

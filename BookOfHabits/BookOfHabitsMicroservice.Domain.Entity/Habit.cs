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
        public Guid OwnerId { get; set; }
        public Person Owner { get; private set; }
        public Guid CardId { get; set; }
        public Card? Card { get; private set; }
        public Guid RoomId { get; set; }
        public Room Room { get; private set; }
        public bool IsUsed { get; private set; }
        public HabitOptions Options { get; private set; }
        public Delay Delay { get; }
        public TimeResetInterval TimeResetInterval { get; }
        public Repetition Repetition { get; }
        public Habit(Guid id, HabitName name, string description, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition, Card? card = null)
            : base(id)
        {
            Name = name;
            Description = description;
            if (card is not null)
                Card = card;
            Options = options;
            Delay = delay;
            TimeResetInterval = timeResetInterval;
            Repetition = repetition;
            IsUsed = false;
        }
        public Habit(HabitName name, string description, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition, Card? card = null)
            : this(Guid.NewGuid(), name, description, options, delay, timeResetInterval, repetition, card)
        {

        }
        protected Habit() : base(Guid.NewGuid())
        {

        }
        public void UseInTheCoins(bool isUsed = true) 
        {        
            IsUsed = isUsed;
        }
        public void SetPerson(Person owner)
        {
            Owner = owner;
            OwnerId = owner.Id;
            Owner.GetHabit(this);
        }
        public void SetRoom(Room room) 
        {
            Room = room;
            Room.GetHabit(this);
        }
        [Obsolete]
        public void GetCard(Card card) 
        {
            if (Card is not null)
                throw new InvalidOperationException($"The card has already been assigned habit {Name}");
            var newCard = card.DeepCopy();
            newCard.Close();
            Card = newCard;
        }
        public void SetCard(Card card)
        {
            Card = card;
        }
        public void SetName(string name) => Name = new HabitName(name);
        public void SetDescription(string description) => Description = description;
        public void SetOptions(HabitOptions options) => Options = options;
        public void UpdateDelay(Delay updateDelay) 
        {
            if (Delay.Id.Equals(updateDelay.Id))
                Delay.Update(updateDelay);
        }
        public void UpdateTimeResetInterval(TimeResetInterval updateTimeResetInterval)
        {
            if (TimeResetInterval.Id.Equals(updateTimeResetInterval.Id))
                TimeResetInterval.Update(updateTimeResetInterval);
        }
        public void UpdateRepetition(Repetition updateRepetition)
        {
            if (Repetition.Id.Equals(updateRepetition.Id))
                Repetition.Update(updateRepetition);
        }
    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Habit : Entity<Guid>
    {
        public HabitCard HabitCard { get; }
        public Room Room { get; }
        public Coins? Coins { get; protected set; }
        public HabitOptions Options { get; }
        public Delay Delay { get; }
        public TimeResetInterval  TimeResetInterval { get; }
        public Repetition Repetition { get; }
        public Habit(Guid id,HabitCard habitCard, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition)
            :base(id)   
        {
            HabitCard = habitCard;
            Room = room;
            Options = options;
            Delay = delay;
            TimeResetInterval = timeResetInterval;
            Repetition = repetition;
        }
        public Habit(HabitCard habitCard, Room room, HabitOptions options, Delay delay, TimeResetInterval timeResetInterval, Repetition repetition)
            : this(Guid.NewGuid(), habitCard, room, options, delay, timeResetInterval, repetition)
        { 
        
        }
        protected Habit(Guid id) : base(id)
        {

        }
        public void UseInTheCoins(Coins coins) => Coins = coins;
    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Coins : Entity<Guid>
    {
        public Room Room { get; }
        public Habit Habit { get; }
        public OptionCoins Options { get; }
        public int CostOfWinning { get; }
        public int Forfeit { get; }
        public int Start { get; }
        public int Falls { get; }

        public Coins(Guid id,Room room, Habit habit, OptionCoins options, int costOfWinning, int forfeit, int start, int falls)
            :base(id)
        {
            Room = room;
            Habit = habit;
            Options = options;
            CostOfWinning = costOfWinning;
            Forfeit = forfeit;
            Start = start;
            Falls = falls;
        }
        public Coins(Room room, Habit habit, OptionCoins options, int costOfWinning, int forfeit, int start, int falls)
            :this(Guid.NewGuid(), room, habit, options, costOfWinning, forfeit, start, falls)
        {
                
        }
        protected Coins(Guid id) : base(id)
        {

        }
    }
}

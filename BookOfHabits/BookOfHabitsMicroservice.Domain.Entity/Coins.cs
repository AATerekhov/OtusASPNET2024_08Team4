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
        public Habit Habit { get; private set; }
        public string Description { get; private set; }
        public CoinsOptions Options { get; private set; }
        public int CostOfWinning { get; private set; }
        public int Forfeit { get; private set; }
        public int Start { get; private set; }
        public int Falls { get; private set; }

        public Coins(Guid id,Room room, Habit habit, CoinsOptions options, int costOfWinning, int forfeit, int start, int falls)
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
        public Coins(Room room, Habit habit, CoinsOptions options, int costOfWinning, int forfeit, int start, int falls)
            :this(Guid.NewGuid(), room, habit, options, costOfWinning, forfeit, start, falls)
        {
                
        }
        protected Coins() : base(Guid.NewGuid())
        {

        }
    }
}

using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Coins : Entity<Guid>
    {
        const int _defaultCost = 10;
        const int _defaultForfeit = 2;
        const int _defaultStart = 100;
        const int _defaultFalls = 10;
        public Room Room { get; }
        public Habit Habit { get; private set; }
        public string? Description { get; private set; }
        public CoinsOptions Options { get; private set; }
        public int CostOfWinning { get; private set; }
        public int Forfeit { get; private set; }
        public int Start { get; private set; }
        public int Falls { get; private set; }

        public Coins(Guid id,Room room, Habit habit, string description, CoinsOptions options, int costOfWinning, int forfeit, int start, int falls)
            :base(id)
        {
            Room = room;
            Habit = habit;
            SetDescription(description);
            SetProperty(options, costOfWinning, forfeit, start, falls);
            Habit.UseInTheCoins();
        }
        public Coins(Room room, Habit habit, string description, CoinsOptions options, int costOfWinning = _defaultCost, int forfeit = _defaultForfeit, int start = _defaultStart, int falls = _defaultFalls)
            :this(Guid.NewGuid(), room, habit, description, options, costOfWinning, forfeit, start, falls)
        {
                
        }
        protected Coins() : base(Guid.NewGuid())
        {

        }
        public void SetDescription(string description) => Description = description;
        public void SetProperty(CoinsOptions options, int costOfWinning, int forfeit, int start, int falls) 
        {
            Options = options;
            CostOfWinning = costOfWinning;
            Forfeit = forfeit;
            Start = start;
            Falls = falls;
        }
    }
}

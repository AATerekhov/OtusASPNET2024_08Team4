using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Models.Room;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Coins
{
    public class CoinsModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public Guid RoomId { get; init; }
        public HabitModel Habit { get; init; }
        public RoomModel Room { get; init; }
        public string? Description { get; init; }
        public CoinsOptions Options { get; init; }
        public int CostOfWinning { get; init; }
        public int Forfeit { get; init; }
        public int Start { get; init; }
        public int Falls { get; init; }
    }
}

using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabitsMicroservice.Application.Models.Room
{
    public class RoomModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public Guid ManagerId { get; init; }
        public required PersonModel Manager { get; init; }
        public required DateTime CreateDate { get; init; }
        public required DateTime UpdateDate { get; init; }
        public bool IsActive { get; init; }
        public required IEnumerable<HabitModel> SuggestedHabits { get; init; }
        public required IEnumerable<CoinsModel> AssignedCoins { get; init; }

    }
}

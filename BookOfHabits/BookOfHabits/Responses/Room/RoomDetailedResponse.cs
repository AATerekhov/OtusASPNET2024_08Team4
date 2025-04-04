using BookOfHabits.Responses.Coins;
using BookOfHabits.Responses.Habit;
using BookOfHabits.Responses.Person;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabits.Responses.Room
{
    public class RoomDetailedResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public Guid ManagerId { get; init; }
        public required PersonShortResponse Manager { get; init; }
        public required DateTime CreateDate { get; init; }
        public required DateTime UpdateDate { get; init; }
        public bool IsActive { get; init; }
        public required IEnumerable<HabitShortResponse> SuggestedHabits { get; init; }
        public required IEnumerable<CoinsShortResponse> AssignedCoins { get; init; }
    }
}

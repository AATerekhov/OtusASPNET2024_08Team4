using BookOfHabits.Responses.Card;
using BookOfHabits.Responses.Person;
using BookOfHabits.Responses.Room;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Habit
{
    public class HabitFullDetailedResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardDetailedResponse? Card { get; init; }
        public Guid OwnerId { get; init; }
        public PersonShortResponse Owner { get; init; }
        public Guid RoomId { get; init; }
        public RoomShortResponse Room { get; init; }
        public bool IsUsed { get; init; }
        public HabitOptions Options { get; init; }
        public required DelayResponse Delay { get; init; }
        public required TimeResetIntervalResponse TimeResetInterval { get; init; }
        public required RepetitionResponse Repetition { get; init; }
    }
}

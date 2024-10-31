using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class DelayModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public bool IsAfterATime { get; init; }
        public int AfterTime { get; init; }
        public bool IsEndless { get; init; }
        public int DurationTime { get; init; }
    }
}

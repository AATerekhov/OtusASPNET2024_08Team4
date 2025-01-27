using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class UpdateDelayModel : ICreateModel
    {
        public bool IsAfterATime { get; init; }
        public int AfterTime { get; init; }
        public bool IsEndless { get; init; }
        public int DurationTime { get; init; }
    }
}

using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class UpdateRepetitionModel : ICreateModel
    {
        public Guid Id { get; init; }
        public int MaxCountPositive { get; init; }
        public int MaxCountNegative { get; init; }
        public bool IsLimit { get; init; }
        public int CountLimit { get; init; }
    }
}

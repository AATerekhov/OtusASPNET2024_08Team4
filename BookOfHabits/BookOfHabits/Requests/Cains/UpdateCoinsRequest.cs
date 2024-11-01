using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Cains
{
    public class UpdateCoinsRequest
    {
        public Guid Id { get; init; }
        public Guid PersonId { get; init; }
        public string? Description { get; init; }
        public CoinsOptions Options { get; init; }
        public int CostOfWinning { get; init; }
        public int Forfeit { get; init; }
        public int Start { get; init; }
        public int Falls { get; init; }
    }
}

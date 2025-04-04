namespace BookOfHabitsMicroservice.Application.Models.Coins
{
    public class ChooseHabitModel
    {
        public Guid PersonId { get; init; }
        public Guid RoomId { get; init; }
        public Guid HabitId { get; init; }
        public required string Description { get; init; }
    }
}

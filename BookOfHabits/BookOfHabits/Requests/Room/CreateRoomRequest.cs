namespace BookOfHabits.Requests.Room
{
    public class CreateRoomRequest
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public Guid ManagerId { get; init; }
        public DateTime CreateDate { get; init; }
    }
}

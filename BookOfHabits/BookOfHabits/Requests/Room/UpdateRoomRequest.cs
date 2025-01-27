namespace BookOfHabits.Requests.Room
{
    public class UpdateRoomRequest
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public bool IsActive { get; init; }
    }
}

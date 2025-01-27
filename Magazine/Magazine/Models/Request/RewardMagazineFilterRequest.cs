namespace MagazineHost.Models.Request
{
    public class RewardMagazineFilterRequest
    {
        public string? Description { get; init; }
        public Guid RoomId { get; init; }
        public Guid MagazineOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

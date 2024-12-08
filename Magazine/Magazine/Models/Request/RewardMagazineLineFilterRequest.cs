namespace MagazineHost.Models.Request
{
    public class RewardMagazineLineFilterRequest
    {
        public Guid MagazineId { get; set; }
        public Guid RewardId { get; set; }
        public required string EventDescription { get; set; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

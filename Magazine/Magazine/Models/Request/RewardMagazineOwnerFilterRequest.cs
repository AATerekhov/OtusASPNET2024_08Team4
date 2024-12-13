namespace MagazineHost.Models.Request
{
    public class RewardMagazineOwnerFilterRequest
    {
        public required string Name { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

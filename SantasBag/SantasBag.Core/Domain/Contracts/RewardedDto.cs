namespace SantasBag.Core.Domain.Contracts
{
    public class RewardedDto //: BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }
        public Guid RoomId { get; set; }
    }
}

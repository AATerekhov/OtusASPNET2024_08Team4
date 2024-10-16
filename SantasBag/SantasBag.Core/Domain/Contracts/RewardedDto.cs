namespace SantasBag.Core.Domain.Contracts
{
    public class RewardedDto
    {
        public required string Name;
        public string? Description;
        public int Cost;
        public Guid RoomId;
    }
}

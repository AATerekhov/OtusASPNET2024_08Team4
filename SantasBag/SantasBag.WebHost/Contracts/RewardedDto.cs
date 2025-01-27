namespace SantasBag.WebHost.Contracts;

public class RewardedDto //: BaseEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string Image { get; set; }
    public int Cost { get; set; }
    public bool InstantBuy {  get; set; }
    public Guid RoomId { get; set; }
}

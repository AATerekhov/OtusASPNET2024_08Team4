using SantasBag.Core.Models;

namespace SantasBag.WebHost.Contracts;

public class RewardTemplate
{
    public required string Name { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Image {  get; set; } = String.Empty;
    public int Cost { get; set; } = 0;
    public bool InstantBuy { get; set; }= true;
    public required Guid RoomId { get; set; }

}

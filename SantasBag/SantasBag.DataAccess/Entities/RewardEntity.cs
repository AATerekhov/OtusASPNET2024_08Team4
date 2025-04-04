using SantasBag.Core.Models;

namespace SantasBag.DataAccess.Entities;

public class RewardEntity :BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public bool InstantBuy { get; set; } = true;
    public Guid RoomId { get; set; }
}

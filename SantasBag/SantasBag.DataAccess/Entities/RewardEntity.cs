using SantasBag.Core.Models;

namespace SantasBug.DataAccess.Entities;

public class RewardEntity :BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public Guid RoomId { get; set; }
}

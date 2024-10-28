using SantasBag.Core.Models;

namespace SantasBag.WebHost.Contracts;

public class RewardTemplate
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Image {  get; set; }
    public int Cost {  get; set; } = 10;
    public bool LimitedCount {  get; set; } = false;
    public int? TotalCount { get; set;}
    public required Guid RoomId { get; set; }

}

namespace SantasBag.Core.Models;

public class Reward : BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public required int Cost { get; set; }
    public required Guid RoomId { get; set; }

    public Reward(string name, string description, string image, int cost, Guid roomId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Image = image;
        Cost = cost;
        RoomId = roomId;
    }



}

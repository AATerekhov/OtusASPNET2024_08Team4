namespace SantasBag.Core.Models;

public class Reward : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Cost { get; set; } = 0;
    public bool InstantBuy { get; set; } = true;
    public Guid RoomId { get; set; }

    private Reward(string name, string description, string image, decimal cost, bool instantBuy, Guid roomId )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Image = image;
        Cost = cost;
        InstantBuy = instantBuy;
        RoomId =roomId;
    }
    private Reward(Guid id, string name, string description, string image, decimal cost, bool instantBuy, Guid roomId)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        Cost = cost;
        InstantBuy = instantBuy;
        RoomId =roomId;
    }

    public static Reward Map(Guid id, string name, string description, string image, decimal cost, bool instantBuy, Guid roomId)
    {
        var reward = new Reward(id, name, description, image, cost, instantBuy, roomId);
        return reward;
    }
    public static Reward Create(string name, string description, string image, decimal cost, bool instantBuy, Guid roomId)
    {
        var reward = new Reward(name, description, image, cost, instantBuy, roomId);
        return reward;
    }



}

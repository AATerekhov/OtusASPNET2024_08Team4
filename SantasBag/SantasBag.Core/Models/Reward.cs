namespace SantasBag.Core.Models;

public class Reward : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Cost { get; set; } = 0;
    public Guid RoomId { get; set; }

    private Reward(string name, string description, string image, decimal cost, Guid roomId )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Image = image;
        Cost = cost;
        //RoomId =roomId;
        RoomId =Guid.Parse( "00000000-0000-0000-0000-000000000000" );  //временно
    }
    private Reward(Guid id, string name, string description, string image, decimal cost, Guid roomId)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        Cost = cost;
        //RoomId =roomId;
        RoomId = Guid.Parse("00000000-0000-0000-0000-000000000000");  //временно
    }

    public static Reward Map(Guid id, string name, string description, string image, decimal cost, Guid roomId)
    {
        var reward = new Reward(id, name, description, image, cost, roomId);
        return reward;
    }
    public static Reward Create(string name, string description, string image, decimal cost, Guid roomId)
    {
        var reward = new Reward(name, description, image, cost, roomId);
        return reward;
    }



}

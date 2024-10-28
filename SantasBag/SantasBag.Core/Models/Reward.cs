namespace SantasBag.Core.Models;

public class Reward : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Cost { get; set; }
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

    public static (Reward Reward, string Error) Create(string name, string description, string image, decimal cost, Guid roomId)
    {
        var error = String.Empty;
        if (string.IsNullOrEmpty(name))
        {
            error = "Name can't be empty";
        }

        var reward = new Reward(name, description, image, cost, roomId);
        return (reward, error);
    }




}

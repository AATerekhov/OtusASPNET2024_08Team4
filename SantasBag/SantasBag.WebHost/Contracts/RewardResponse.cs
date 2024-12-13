namespace SantasBag.Contracts
{
    public record RewardResponse(
        Guid Id,
        string Name,
        string Description,
        string Image,
        decimal Cost,
        Guid RoomId);
}
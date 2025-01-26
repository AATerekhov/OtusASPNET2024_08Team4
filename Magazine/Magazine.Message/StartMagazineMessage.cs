namespace RoomsDesigner.Application.Messages
{
    public class StartMagazineMessage
    {
        public Guid RoomId { get; init; }
        public required string Description { get; init; }
        public Guid MagazineOwnerId { get; init; }
    }
}

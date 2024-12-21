namespace RoomsDesigner.Application.Messages
{
    public class CreateRoomMessage
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
    }
}

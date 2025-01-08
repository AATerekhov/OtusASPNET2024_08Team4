namespace RoomsDesigner.Application.Messages
{
    public class StartDiaryMessage
    {
        public Guid RoomId { get; init; }
        public required string Description { get; init; }
        public Guid DiaryOwnerId { get; init; }
    }
}

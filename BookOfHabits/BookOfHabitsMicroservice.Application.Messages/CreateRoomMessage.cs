namespace RoomsDesigner.Application.Messages
{
    public class CreateRoomMessage
    {
        public Guid CaseId { get; init; }
        public required string CaseName { get; init; }
        public required string UserMail { get; init; }
        public Guid OwnerId { get; init; }
    }
}

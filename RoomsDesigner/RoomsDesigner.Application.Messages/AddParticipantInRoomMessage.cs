namespace RoomsDesigner.Application.Messages
{
    public class AddParticipantInRoomMessage
    {
        public Guid Id { get; init; }
        public required string UserMail { get; init; }
        public Guid CaseId { get; init; }
    }
}

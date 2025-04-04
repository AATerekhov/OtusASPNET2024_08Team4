namespace RoomsDesigner.Application.Messages
{
    public class AddParticipantInRoomMessage
    {
        public Guid PartisipantId { get; init; }
        public Guid CaseId { get; init; }
        public required string UserMail { get; init; }
        public Guid OwnerId { get; init; }
    }
}

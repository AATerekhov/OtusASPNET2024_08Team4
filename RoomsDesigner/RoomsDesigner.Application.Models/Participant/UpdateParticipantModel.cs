namespace RoomsDesigner.Application.Models.Participant
{
    public class UpdateParticipantModel
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public required string UserMail { get; init; }
        public string? Name { get; init; }
        public Guid CaseId { get; init; }
    }
}

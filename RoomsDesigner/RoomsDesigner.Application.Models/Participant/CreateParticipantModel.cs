namespace RoomsDesigner.Application.Models.Participant
{
    public class CreateParticipantModel
    {
        public required string UserMail { get; init; }
        public Guid CaseId { get; init; }
    }
}

namespace RoomsDesigner.Application.Models.Participant
{
    public class UpdateParticipantModel
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public required string UserMail { get; init; }
        public required string Name { get; init; }
    }
}

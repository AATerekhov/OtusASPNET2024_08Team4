using RoomsDesigner.Application.Models.Base;

namespace RoomsDesigner.Application.Models.Participant
{
    public class ParticipantModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public required string UserMail { get; init; }
        public string? Name { get; init; }
        public Guid CaseId { get; init; }
    }
}

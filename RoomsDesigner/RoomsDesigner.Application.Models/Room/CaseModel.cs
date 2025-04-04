using RoomsDesigner.Application.Models.Base;
using RoomsDesigner.Application.Models.Participant;

namespace RoomsDesigner.Application.Models.Room
{
    public class CaseModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
        public required IEnumerable<ParticipantModel> Players { get; init; }
        public bool IsActive { get; init; }
    }
}

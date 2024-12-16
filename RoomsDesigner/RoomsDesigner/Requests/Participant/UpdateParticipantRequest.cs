using System;

namespace RoomsDesigner.Api.Requests.Participant
{
    public class UpdateParticipantRequest
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public required string UserMail { get; init; }
        public required string Name { get; init; }
    }
}

using System;

namespace RoomsDesigner.Api.Responses.Participant
{
    public class ParticipantShortResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public required string UserMail { get; init; }
        public string Name { get; init; }
        public bool IsConfirm => !string.IsNullOrEmpty(Name);
    }
}

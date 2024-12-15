using System;

namespace RoomsDesigner.Api.Requests.Participant
{
    public class CreateParticipantRequest
    {
        public required string UserMail { get; init; }
        public Guid CaseId { get; init; }
    }
}

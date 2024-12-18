using RoomsDesigner.Api.Responses.Participant;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.Api.Responses.Case
{
    public class CaseDetailedResponse
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
        public required IEnumerable<ParticipantShortResponse> Players { get; init; }
    }
}

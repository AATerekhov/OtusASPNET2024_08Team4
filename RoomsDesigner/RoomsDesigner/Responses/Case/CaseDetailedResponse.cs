using RoomsDesigner.Application.Models.Participant;
using System.Collections.Generic;
using System;
using RoomsDesigner.Api.Responses.Participant;

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

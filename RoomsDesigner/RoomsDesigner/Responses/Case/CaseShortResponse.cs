using System;

namespace RoomsDesigner.Api.Responses.Case
{
    public class CaseShortResponse
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
    }
}

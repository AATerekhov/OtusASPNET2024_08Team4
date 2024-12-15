using System;

namespace RoomsDesigner.Api.Requests.Case
{
    public class UpdateCaseRequest
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
    }
}

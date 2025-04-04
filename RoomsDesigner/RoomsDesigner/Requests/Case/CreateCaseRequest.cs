using System;

namespace RoomsDesigner.Api.Requests.Case
{
    public class CreateCaseRequest
    {
        public Guid OwnerId { get; init; }
        public required string UserMail { get; init; }
        public required string Name { get; init; }
    }
}

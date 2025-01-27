using System;

namespace RoomsDesigner.Api.Requests.Case
{
    public class LaunchRequest
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
    }
}

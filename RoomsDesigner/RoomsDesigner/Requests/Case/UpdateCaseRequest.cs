using System;

namespace RoomsDesigner.Api.Requests.Case
{
    public class UpdateCaseRequest:CreateCaseRequest
    {
        public Guid Id { get; init; }
    }
}

using FluentValidation;
using RoomsDesigner.Api.Requests.Case;
using System;

namespace RoomsDesigner.Api.Infrastructure.Validators
{
    public class LaunchValidator : AbstractValidator<LaunchRequest>
    {
        public LaunchValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID select entity cannot be empty.");
            RuleFor(x => x.OwnerId)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID owner cannot be empty.");
        }
    }
}

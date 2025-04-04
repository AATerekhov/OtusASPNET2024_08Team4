using FluentValidation;
using RoomsDesigner.Api.Requests.Case;
using System;

namespace RoomsDesigner.Api.Infrastructure.Validators
{
    public class CreateCaseValidator<T> : AbstractValidator<T> where T : CreateCaseRequest
    {
        public CreateCaseValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.OwnerId)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID owner cannot be empty.");
        }
    }
}

using FluentValidation;
using RoomsDesigner.Api.Requests.Case;
using System;

namespace RoomsDesigner.Api.Infrastructure.Validators
{
    public class UpdateCaseValidator: CreateCaseValidator<UpdateCaseRequest>
    {
        public UpdateCaseValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID select entity cannot be empty.");
        }
    }
}

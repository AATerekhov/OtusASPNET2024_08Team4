using FluentValidation;
using RoomsDesigner.Api.Requests.Participant;
using System;

namespace RoomsDesigner.Api.Infrastructure.Validators
{
    public class CreateParticipantValidator : AbstractValidator<CreateParticipantRequest>
    {
        public CreateParticipantValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().EmailAddress();
            RuleFor(x => x.CaseId)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID case cannot be empty.");
        }
    }
}

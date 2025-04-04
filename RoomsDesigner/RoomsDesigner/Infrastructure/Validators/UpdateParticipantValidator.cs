using FluentValidation;
using RoomsDesigner.Api.Requests.Participant;
using System;

namespace RoomsDesigner.Api.Infrastructure.Validators
{
    public class UpdateParticipantValidator : AbstractValidator<UpdateParticipantRequest>
    {
        public UpdateParticipantValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.UserMail).NotEmpty().EmailAddress();                
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID user cannot be empty."); 
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("GUID select entity cannot be empty.");
        }
    }
}

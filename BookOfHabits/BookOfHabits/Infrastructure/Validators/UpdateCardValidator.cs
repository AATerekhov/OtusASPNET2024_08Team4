using BookOfHabits.Requests.Card;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class UpdateCardValidator : BaseCommonValidator<UpdateCardRequest>
    {
        public UpdateCardValidator()
        {
            RuleFor(x => x.Options)
                .Must(CreateCardValidator.ValidateOptionsField)
                .WithMessage($"There are not so many flags for this option {nameof(CardOptions)}");
            RuleFor(x => x.TitleCheckElements)
                .NotNull();
        }
    }
}

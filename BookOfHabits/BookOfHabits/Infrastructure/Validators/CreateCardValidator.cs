using BookOfHabits.Requests.Card;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class CreateCardValidator : BaseCommonValidator<CreateCardRequest>
    {
        public CreateCardValidator()
        {
            RuleFor(x => x.Options)
                .Must(ValidateOptionsField)
                .WithMessage($"There are not so many flags for this option {nameof(CardOptions)}");
            RuleFor(x => x.TitleCheckElements)
                .NotNull();
        }
        internal static bool ValidateOptionsField(CardOptions options)
            => (int)options <= (int)CardOptions.All;
    }
}

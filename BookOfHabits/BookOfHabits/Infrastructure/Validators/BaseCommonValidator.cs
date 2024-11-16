using BookOfHabits.Requests;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class BaseCommonValidator<T> : AbstractValidator<T> where T : BaseCommonRequest
    {
        public BaseCommonValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .NotNull()
                .MaximumLength(250);
        }
    }
}

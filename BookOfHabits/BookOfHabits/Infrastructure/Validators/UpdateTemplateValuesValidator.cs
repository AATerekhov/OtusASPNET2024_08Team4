using BookOfHabits.Requests.Card;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class UpdateTemplateValuesValidator: AbstractValidator<UpdateTemplateValuesRequest>
    {
        public UpdateTemplateValuesValidator()
        {
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.TitleValue).NotNull().MaximumLength(150);
            RuleFor(x => x.TitleCheck).NotNull().MaximumLength(100);
            RuleFor(x => x.TitleReportField).NotNull().MaximumLength(150);
            RuleFor(x => x.Tags).NotNull();
            RuleFor(x => x.TitlePositive).NotNull().MaximumLength(100);
            RuleFor(x => x.TitleNegative).NotNull().MaximumLength(100);
        }
    }
}

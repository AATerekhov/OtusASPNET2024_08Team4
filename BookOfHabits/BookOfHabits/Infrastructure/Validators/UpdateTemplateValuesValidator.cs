using BookOfHabits.Requests.Card;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class UpdateTemplateValuesValidator: AbstractValidator<UpdateTemplateValuesRequest>
    {
        public UpdateTemplateValuesValidator()
        {
            RuleFor(x => x.TitleStatus).NotNull().MaximumLength(128);
            RuleFor(x => x.TitleValue).NotNull().MaximumLength(150);
            RuleFor(x => x.TitleCheck).NotNull().MaximumLength(100);
            RuleFor(x => x.TitleReportField).NotNull().MaximumLength(150);
            RuleFor(x => x.TitleTags).NotNull().MaximumLength(128);
            RuleFor(x => x.TitlePositive).NotNull().MaximumLength(100);
            RuleFor(x => x.TitleNegative).NotNull().MaximumLength(100);
            RuleFor(x => x.TitleFileReceiver).NotNull().MaximumLength(128);
        }
    }
}

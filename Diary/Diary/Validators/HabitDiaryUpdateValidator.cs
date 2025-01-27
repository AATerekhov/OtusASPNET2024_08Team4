using Diary.Models.Request;
using FluentValidation;

namespace Diary.Validators
{
    public class HabitDiaryUpdateValidator : AbstractValidator<EditHabitDiaryRequest>
    {
        public HabitDiaryUpdateValidator()
        {
            RuleFor(x => x.Description).Length(0, 100).WithMessage("Максимальная длина описания дневника не может превышать 100");
        }
    }
}

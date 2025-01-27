using Diary.Models.Request;
using FluentValidation;

namespace Diary.Validators
{
    public class HabitDiaryCreateValidator : AbstractValidator<CreateHabitDiaryRequest>
    {
        public HabitDiaryCreateValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.DiaryOwnerId).NotEmpty();
            RuleFor(x => x.TotalCost).GreaterThan(0).WithMessage("Начальные баллы не могут быть меньше 0");
            RuleFor(x => x.Description).Length(0, 100).WithMessage("Максимальная длина описания дневника не может превышать 100");
        }

    }
}

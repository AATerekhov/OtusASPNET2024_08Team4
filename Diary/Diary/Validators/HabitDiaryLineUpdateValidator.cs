﻿using Diary.BusinessLogic.Helpers;
using Diary.Models.Request;
using FluentValidation;
using System.Globalization;

namespace Diary.Validators
{
    public class HabitDiaryLineUpdateValidator : AbstractValidator<EditHabitDiaryLineRequest>
    {
        public HabitDiaryLineUpdateValidator()
        {
            RuleFor(x => x.ModifiedDate)
                .Must(modifiedDate => DateTime.TryParseExact(modifiedDate, DateTimeHelper.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                .WithMessage($"Текущая дата не подходит под формат {DateTimeHelper.DateFormat}");
            RuleFor(x => x.EventDescription).Length(0, 100).WithMessage("Максимальная длина описания события не может превышать 100");
        }
    }
}

using FluentValidation;
using Magazine.BusinessLogic.Helpers;
using MagazineHost.Models.Request;
using System.Globalization;

namespace MagazineHost.Validators
{
    public class RewardMagazineLineCreateValidator : AbstractValidator<CreateRewardMagazineLineRequest>
    {
        public RewardMagazineLineCreateValidator()
        {
            RuleFor(x => x.MagazineId).NotEmpty();
            RuleFor(x => x.RewardId).NotEmpty();
            RuleFor(x => x.ModifiedDate)
               .Must(modifiedDate => DateTime.TryParseExact(modifiedDate, DateTimeHelper.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
               .WithMessage($"Текущая дата не подходит под формат {DateTimeHelper.DateFormat}");
            RuleFor(x => x.EventDescription).Length(0, 100).WithMessage("Максимальная длина описания события не может превышать 100");
        }
    }
}

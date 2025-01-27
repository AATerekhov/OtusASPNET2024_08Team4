using FluentValidation;
using MagazineHost.Models.Request;

namespace MagazineHost.Validators
{
    public class RewardMagazineUpdateValidator : AbstractValidator<EditRewardMagazineRequest>
    {
        public RewardMagazineUpdateValidator()
        {
            RuleFor(x => x.Description).Length(0, 100).WithMessage("Максимальная длина описания журнала магазина не может превышать 100");
        }
    }
}

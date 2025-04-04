using FluentValidation;
using MagazineHost.Models.Request;

namespace MagazineHost.Validators
{
    public class RewardMagazineCreateValidator : AbstractValidator<CreateRewardMagazineRequest>
    {
        public RewardMagazineCreateValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.MagazineOwnerId).NotEmpty();
            RuleFor(x => x.TotalCost).GreaterThan(0).WithMessage("Общая стоимость не может быть меньше 0");
            RuleFor(x => x.Description).Length(0, 100).WithMessage("Максимальная длина описания журнала магазина не может превышать 100");
        }
    }
}

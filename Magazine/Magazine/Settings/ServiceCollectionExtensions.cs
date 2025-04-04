using FluentValidation;
using MagazineHost.Validators;

namespace Diary.Settings
{
    public static class ServiceCollectionExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RewardMagazineCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<RewardMagazineLineCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<RewardMagazineLineUpdateValidator>();
            services.AddValidatorsFromAssemblyContaining<RewardMagazineUpdateValidator>();
        }
    }
}

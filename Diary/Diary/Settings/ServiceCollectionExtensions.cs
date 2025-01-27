using Diary.Validators;
using FluentValidation;

namespace Diary.Settings
{
    public static class ServiceCollectionExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<HabitDiaryCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<HabitDiaryLineCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<HabitDiaryLineUpdateValidator>();
            services.AddValidatorsFromAssemblyContaining<HabitDiaryUpdateValidator>();
        }
    }
}

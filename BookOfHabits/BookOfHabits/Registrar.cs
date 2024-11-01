using BookOfHabits.Infrastructure.Settings;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Implementations;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.PropertyRepository;
using Microsoft.EntityFrameworkCore;

namespace BookOfHabits
{
    public static class Registrar
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Person, Guid>, PersonRepository>();
            services.AddScoped<IRepository<Room, Guid>, RoomRepository>();
            services.AddScoped<IRepository<TemplateValues, Guid>, TemplateValuesRepository>();
            services.AddScoped<IRepository<Card, Guid>, CardRepository>();
            services.AddScoped<IRepository<Delay, Guid>, DelayRepository>();
            services.AddScoped<IRepository<Repetition, Guid>, RepetitionRepository>();
            services.AddScoped<IRepository<TimeResetInterval, Guid>, TimeResetIntervalRepository>();
            services.AddScoped<IRepository<Habit, Guid>, HabitRepository>();
            services.AddScoped<ICoinsRepository, CoinsRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonsApplicationService, PersonsApplicationService>();
            services.AddScoped<IRoomsApplicationService, RoomsApplicationService>();
            services.AddScoped<ICardsApplicationService, CardsApplicationService>();
            services.AddScoped<IHabitsApplicationService, HabitsApplicationService>();
            services.AddScoped<IInstallCardApplicationService, InstallCardApplicationService>();
            services.AddScoped<ICoinsApplicationService, CoinsApplicationService>();
            services.AddScoped<IChooseHabitApplicationService, ChooseHabitApplicationService>();
            return services;
        }

        public static IServiceCollection AddApplicationDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.Get<ApplicationSettings>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(settings.ConnectionString,
                optionsBuilder => optionsBuilder.MigrationsAssembly("BookOfHabitsMicroservice.Infrastructure.EntityFramework"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            return services;
        }

    }
}

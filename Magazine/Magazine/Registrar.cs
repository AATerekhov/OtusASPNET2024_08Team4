using Magazine.BusinessLogic.Services;
using Magazine.BusinessLogic.Services.Implementatios;
using Magazine.Core.Domain.Abstractions;
using Magazine.DataAccess.Abstractions;
using Magazine.DataAccess.Repositories;
using MagazineHost.Settings;

namespace MagazineHost
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .InstallRepositories();
            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                 .AddScoped<IRewardMagazineService, RewardMagazineService>()
                 .AddScoped<IRewardMagazineOwnerService, RewardMagazineOwnerService>()
                 .AddScoped<IRewardMagazineLineService, RewardMagazineLineService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IRewardMagazineRepository, RewardMagazineRepository>()
                .AddScoped<IRewardMagazineOwnerRepository, RewardMagazineOwnerRepository>()
                .AddScoped<IRewardMagazineLineRepository, RewardMagazineLineRepository>();

            return serviceCollection;
        }
    }
}

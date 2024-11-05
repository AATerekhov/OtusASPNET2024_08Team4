using Diary.Settings;
using Diary.DataAccess;
using System.ComponentModel.Design;
using Diary.DataAccess.Abstractions;
using Diary.DataAccess.Repositories;
using Diary.BusinessLogic.Services;
using Diary.BusinessLogic.Services.Implementation;

namespace Diary
{
    public static class  Registrar
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
                 .AddTransient<IJournalService, JournalService>()
                 .AddTransient<IJournalOwnerService, JournalOwnerService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IJournalOwnerRepository, JournalOwnerRepository>()
                .AddTransient<IJournaRepository, JournalRepository>();
          
            return serviceCollection;
        }
    }
}

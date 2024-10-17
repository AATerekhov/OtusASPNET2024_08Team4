using Diary.Settings;
using Diary.DataAccess;

namespace Diary
{
    public static class  Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    //.InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString);
                    //.InstallRepositories();
            return services;
        }
    }
}

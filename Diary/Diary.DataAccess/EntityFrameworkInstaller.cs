using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Diary.DataAccess
{
    public static  class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
        string connectionString)
        {
            services.AddDbContext<EfDbContext>(optionsBuilder
                => optionsBuilder
                    .UseSqlite(connectionString));

            return services;
        }

        public static async Task MigrationDataBaseAsync(this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;

            await using var db = services.GetRequiredService<EfDbContext>();
            try
            {
                await db.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                //TODO: Add logging
                throw;
            }
        }
    }
}

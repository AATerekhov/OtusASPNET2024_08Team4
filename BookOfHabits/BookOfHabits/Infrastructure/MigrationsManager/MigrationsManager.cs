using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookOfHabits.Infrastructure.MigrationsManager
{
    public static class MigrationsManager
    {      
        public static void MigrateDatabase<T>(this IApplicationBuilder application) where T : ApplicationDbContext
        {
            var scope = application.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();

            dbContext.Database.Migrate();
        }
    }
}

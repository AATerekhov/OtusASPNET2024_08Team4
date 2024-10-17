using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}

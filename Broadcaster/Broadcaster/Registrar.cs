using Broadcaster.Application.Services.Abstractions;
using Broadcaster.Application.Services.Implementations;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.Implementations;
using BroadcasterMicroservice.Infrastructure.MongoDbContext;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;

namespace Broadcaster
{
    public static class Registrar
    {
        public static IServiceCollection AddMongoContext(this IServiceCollection services)
        {
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IHabitNotificationRepository, HabitNotificationRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHabitNotificationService, HabitNotificationService>();
            return services;
        }

    }
}

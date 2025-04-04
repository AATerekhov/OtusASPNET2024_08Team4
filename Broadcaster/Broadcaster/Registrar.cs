using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Application.Services.Abstractions;
using Broadcaster.Application.Services.Implementations;
using Broadcaster.Application.Services.Implementations.FactoryMethodDomain;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
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
            services.AddScoped<IFactory<CreateHabitNotificationModel, HabitNotifucationMongo>, HabitNotificationCreator>();
            return services;
        }

    }
}

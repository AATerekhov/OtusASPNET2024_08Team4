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
    }
}

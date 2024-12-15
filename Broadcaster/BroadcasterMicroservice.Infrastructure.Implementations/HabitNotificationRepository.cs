using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.Implementations.Base;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;
using MongoDB.Driver;

namespace BroadcasterMicroservice.Infrastructure.Implementations
{
    public class HabitNotificationRepository (IMongoDBContext context): BaseRepository<HabitNotifucationMongo, HabitNotification, Guid>(context), IHabitNotificationRepository
    {
        public async Task<HabitNotifucationMongo?> GetByIdHabitAsync(Guid id, CancellationToken token = default)
        {
            var all = await _dbCollection.FindAsync(Builders<HabitNotifucationMongo>.Filter.Where(x=> x.Object.Id.Equals(id)), cancellationToken: token);
            return  (await all.ToListAsync(cancellationToken: token)).FirstOrDefault();
        }
    }
}

using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Entity.MongoModel;

namespace BroadcasterMicroservice.Domain.Repository.Abstractions
{
    public interface IHabitNotificationRepository : IMongoRepository<HabitNotifucationMongo, HabitNotification, Guid>
    {
    }
}

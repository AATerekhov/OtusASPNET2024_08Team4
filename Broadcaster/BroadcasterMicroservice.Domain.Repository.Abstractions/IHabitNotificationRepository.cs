using BroadcasterMicroservice.Domain.Entity;

namespace BroadcasterMicroservice.Domain.Repository.Abstractions
{
    public interface IHabitNotificationRepository : IRepository<HabitNotification, Guid>
    {
    }
}

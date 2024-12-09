using Broadcaster.Application.Models.HabitNotification;
using Broadcaster.Application.Services.Abstractions;
using BroadcasterMicroservice.Domain.Repository.Abstractions;

namespace Broadcaster.Application.Services.Implementations
{
    public class HabitNotificationService(IHabitNotificationRepository notificationRepository) : IHabitNotificationService
    {
        public async Task<HabitNotificationModel?> AddNotificationAsync(CreateHabitNotificationModel notificationInfo, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HabitNotificationModel>> GetAllNotificationsAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<HabitNotificationModel?> GetNotificationByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}

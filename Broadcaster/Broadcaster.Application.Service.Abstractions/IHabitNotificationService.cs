using Broadcaster.Application.Models.HabitNotification;

namespace Broadcaster.Application.Services.Abstractions
{
    public interface IHabitNotificationService
    {
        Task<IEnumerable<HabitNotificationModel>> GetAllNotificationsAsync(CancellationToken token = default);
        Task<HabitNotificationModel?> GetNotificationByIdAsync(Guid id, CancellationToken token = default);
        Task<HabitNotificationModel?> AddNotificationAsync(CreateHabitNotificationModel notificationInfo, CancellationToken token = default);
        Task DeletedNotification(Guid id, CancellationToken token = default);
    }
}

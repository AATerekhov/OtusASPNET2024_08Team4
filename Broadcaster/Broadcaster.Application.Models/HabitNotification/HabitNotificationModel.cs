using Broadcaster.Application.Models.Base;

namespace Broadcaster.Application.Models.HabitNotification
{
    public class HabitNotificationModel
    {
        public required string ObjectId { get; init; }
        public Guid Id { get; init; }
        public required NotificationMessageModel NotificationMessage { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime FinishHabit { get;  init; }
        public int Beforehand { get;  init; }
    }
}

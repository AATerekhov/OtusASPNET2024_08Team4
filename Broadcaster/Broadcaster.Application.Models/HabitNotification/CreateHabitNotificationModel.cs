using Broadcaster.Application.Models.Base;

namespace Broadcaster.Application.Models.HabitNotification
{
    public class CreateHabitNotificationModel
    {
        public Guid Id { get; init; }
        public required string Message { get; init; }
        public required string Addressee { get; init; }
        public DateTime FinishHabit { get; init; }
        public int Beforehand { get; init; }
    }
}

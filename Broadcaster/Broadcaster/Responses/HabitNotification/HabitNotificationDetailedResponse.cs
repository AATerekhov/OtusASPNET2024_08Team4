using Broadcaster.Application.Models.Base;

namespace Broadcaster.Responses.HabitNotification
{
    public class HabitNotificationDetailedResponse
    {
        public required string ObjectId { get; init; }
        public Guid Id { get; init; }
        public required string Message { get; init; }
        public required string Sender { get; init; }
        public required string Addressee { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime FinishHabit { get; init; }
        public int Beforehand { get; init; }
    }
}

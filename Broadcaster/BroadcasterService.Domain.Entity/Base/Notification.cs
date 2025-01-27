using BroadcasterMicroservice.Domain.ValueObject;
using BroadcasterService.Domain.Entity.Base;

namespace BroadcasterMicroservice.Domain.Entity.Base
{
    public abstract class Notification : Entity<Guid>
    {
        public NotificationMessage NotificationMessage { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        protected Notification(Guid id, NotificationMessage notificationMessage) : base(id)
        {
            NotificationMessage = notificationMessage;
        }
        public virtual void Deleted() => IsDeleted = true;
        public virtual NotificationMessage? Send() => NotificationMessage;
    }
}

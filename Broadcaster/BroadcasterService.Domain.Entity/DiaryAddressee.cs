using BroadcasterMicroservice.Domain.Entity.Base;
using BroadcasterMicroservice.Domain.Entity.Exceptions;
using BroadcasterMicroservice.Domain.ValueObject;

namespace BroadcasterMicroservice.Domain.Entity
{
    public class DiaryAddressee : Addressee

    {
        private readonly ICollection<HabitNotification> _habits = [];
        public IReadOnlyCollection<HabitNotification> HabitsActive => _habits.Where(notification => !notification.IsDeleted).ToList().AsReadOnly();
        public DiaryAddressee(Guid id, string name) : base(id, name)
        {

        }
        public void AddNotification(HabitNotification notification)
        {
            if (_habits.Contains(notification))
                throw new DoubleEnrollmentException(notification, this);
            _habits.Add(notification);
        }
        public override IEnumerable<NotificationMessage> Notify() => HabitsActive.Select(x => x.Send()).Where(x => x is not null);
    }
}

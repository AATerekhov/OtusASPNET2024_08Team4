namespace BroadcasterMicroservice.Domain.Entity.Exceptions
{
    public class DoubleEnrollmentException(HabitNotification notification, DiaryAddressee addressee) : InvalidOperationException($"{notification.NotificationMessage} has been enrolled yo group {addressee.Name} yet")
    {
        public HabitNotification Notification => notification;
        public DiaryAddressee Addressee => addressee;
    }
}

using BroadcasterMicroservice.Domain.Entity.Base;
using BroadcasterMicroservice.Domain.ValueObject;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BroadcasterMicroservice.Domain.Entity
{
    public class HabitNotification : Notification
    {
        [BsonDateTimeOptions(Representation = BsonType.String)]
        public DateTime FinishHabit { get; private set; }
        //Seconds
        public int Beforehand { get; private set; }
        public HabitNotification(Guid id, string message, string addressee, DateTime finishHabitm, int befirehand) : base(id, new NotificationMessage(message, addressee))
        {
            FinishHabit = finishHabitm;
            Beforehand = befirehand;
        }
        public override NotificationMessage? Send() => (DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) > FinishHabit - TimeSpan.FromSeconds(Beforehand)) switch
        {
            true => NotificationMessage,
            false => null
        };
    }
}

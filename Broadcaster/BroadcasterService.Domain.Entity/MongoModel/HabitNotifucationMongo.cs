namespace BroadcasterMicroservice.Domain.Entity.MongoModel
{
    public class HabitNotifucationMongo:MongoEntity<HabitNotification, Guid>
    {
        public HabitNotifucationMongo(HabitNotification entity):base(entity)
        {
        }
        protected HabitNotifucationMongo() : base(null) 
        {
        }
    }
}

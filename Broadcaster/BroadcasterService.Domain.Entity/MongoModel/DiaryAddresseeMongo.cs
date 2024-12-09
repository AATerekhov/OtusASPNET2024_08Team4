namespace BroadcasterMicroservice.Domain.Entity.MongoModel
{
    public class DiaryAddresseeMongo: MongoEntity<DiaryAddressee, Guid>
    {
        public DiaryAddresseeMongo(DiaryAddressee entity) : base(entity)
        {
        }
        protected DiaryAddresseeMongo() : base(null)
        {
        }
    }
}

namespace BroadcasterMicroservice.Domain.Entity.MongoModel
{
    public class AddressGroupMongo : MongoEntity<AddressGroup, Guid>
    {
        public AddressGroupMongo(AddressGroup entity) : base(entity)
        {
        }
        protected AddressGroupMongo() : base(null) 
        {        
        }
    }
}

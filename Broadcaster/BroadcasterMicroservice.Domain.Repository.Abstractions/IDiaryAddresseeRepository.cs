using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Entity.MongoModel;

namespace BroadcasterMicroservice.Domain.Repository.Abstractions
{
    public interface IDiaryAddresseeRepository:IMongoRepository<DiaryAddresseeMongo,DiaryAddressee,Guid>
    {
    }
}

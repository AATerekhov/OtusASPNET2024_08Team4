using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.Implementations.Base;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;

namespace BroadcasterMicroservice.Infrastructure.Implementations
{
    public class DiaryAddresseeRepository(IMongoDBContext context) : BaseRepository<DiaryAddressee,Guid>(context), IDiaryAddresseeRepository
    {
       
    }
}

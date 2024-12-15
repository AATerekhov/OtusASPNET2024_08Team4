using BroadcasterMicroservice.Domain.Entity;
using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.Implementations.Base;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;

namespace BroadcasterMicroservice.Infrastructure.Implementations
{
    public class AddressGroupRepository(IMongoDBContext context) : BaseRepository<AddressGroupMongo, AddressGroup, Guid>(context), IAddressGroupeRepository
    {
    }
}

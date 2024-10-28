using SantasBag.Core.Models;

namespace SantasBug.Core.Abstractions;

public interface IRewardsRepository
{
    Task<Guid> Create(Reward book);
    Task<Guid> Delete(Guid id);
    Task<List<Reward>> Get();
    Task<Guid> Update(Guid id, string name, string description, string image, decimal cost, Guid roomId);
}
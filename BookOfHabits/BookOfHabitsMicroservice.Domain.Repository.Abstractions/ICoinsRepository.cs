using BookOfHabitsMicroservice.Domain.Entity;

namespace BookOfHabitsMicroservice.Domain.Repository.Abstractions
{
    public interface ICoinsRepository: IRepository<Coins, Guid>
    {
        Task<Coins?> GetDetailedCoinsByIdAsync(Guid id, CancellationToken token = default);
        Task<Coins?> GetCoinsByIdAsync(Guid id, CancellationToken token = default);
    }
}

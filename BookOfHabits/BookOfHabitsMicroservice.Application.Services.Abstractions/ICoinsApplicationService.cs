using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Models.Habit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface ICoinsApplicationService
    {
        Task<IEnumerable<CoinsModel>> GetAllRoomCoinsAsync(Guid roomId, CancellationToken token = default);
        Task<CoinsModel> GetCoinsByIdAsync(Guid id, CancellationToken token = default);
        Task<bool> UpdateCoins(UpdateCoinsModel coinsInfo, CancellationToken token = default);
        Task<bool> DeleteCoins(Guid id, CancellationToken token = default);
    }
}

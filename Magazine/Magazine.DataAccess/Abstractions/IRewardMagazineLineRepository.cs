using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Magazines;
using Magazine.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.DataAccess.Abstractions
{
    public interface IRewardMagazineLineRepository : IRepository<RewardMagazineLine>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список строк журнала наград </returns>
        Task<List<RewardMagazineLine>> GetPagedAsync(RewardMagazineLineFilterModel filterModel, CancellationToken cancellationToken);

        /// <summary>
        /// Получение всех строк по гуиду журнала
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список строк конкретного журнала наград</returns>
        Task<List<RewardMagazineLine>> GetAllByMagazineIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

using Magazine.Core.Domain.Magazines;
using Magazine.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Abstractions
{
    public interface IRewardMagazineRepository : IRepository<RewardMagazine>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список журналов наград</returns>
        Task<List<RewardMagazine>> GetPagedAsync(RewardMagazineFilterModel filterModel, CancellationToken cancellationToken);

        /// <summary>
        /// Получить журналы наград по гуиду владельца
        /// </summary>
        /// <param name="id"> Гуид владельца</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список журналов наград</returns>
        Task<List<RewardMagazine>> GetAllByMagazineOwnerIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

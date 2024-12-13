using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.Magazines;
using Magazine.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Abstractions
{
    public interface IRewardMagazineOwnerRepository : IRepository<RewardMagazineOwner>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список владельцев журналов наград </returns>
        Task<List<RewardMagazineOwner>> GetPagedAsync(RewardMagazineOwnerFilterModel filterModel, CancellationToken cancellationToken);
    }
}

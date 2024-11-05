using Diary.Core.Abstractions;
using Diary.Core.Domain.Administration;
using Diary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Abstractions
{
    public interface IJournalOwnerRepository : IRepository<JournalOwner>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> иодель фильтра. </param>
        /// <returns> Список владельцев дневников </returns>
        Task<List<JournalOwner>> GetPagedAsync(JournalOwnerFilterModel filterModel, CancellationToken cancellationToken);
    }
}

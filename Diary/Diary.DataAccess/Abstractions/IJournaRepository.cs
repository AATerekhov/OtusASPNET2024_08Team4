using Diary.Core.Abstractions;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
using Diary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Abstractions
{
    public interface IJournaRepository : IRepository<Journal>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список журналов </returns>
        Task<List<Journal>> GetPagedAsync(JournalFilterModel filterModel, CancellationToken cancellationToken);
    }
}

using Diary.Core.Abstractions;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using Diary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Abstractions
{
    public interface IHabitDiaryLineRepository : IRepository<HabitDiaryLine>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список строк дневников </returns>
        Task<List<HabitDiaryLine>> GetPagedAsync(HabitDiaryLineFilterModel filterModel, CancellationToken cancellationToken);

        /// <summary>
        /// Получение всех строк по гуиду журнала
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список строк конкретного дневника</returns>
        Task<List<HabitDiaryLine>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

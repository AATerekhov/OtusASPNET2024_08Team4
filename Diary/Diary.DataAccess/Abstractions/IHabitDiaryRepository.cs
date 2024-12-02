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
    public interface IHabitDiaryRepository : IRepository<Diary.Core.Domain.Diary.HabitDiary>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список журналов </returns>
        Task<List<HabitDiary>> GetPagedAsync(HabitDiaryFilterModel filterModel, CancellationToken cancellationToken);
    }
}

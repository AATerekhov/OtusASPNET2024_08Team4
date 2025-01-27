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
    public interface IHabitDiaryRepository : IRepository<HabitDiary>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> модель фильтра. </param>
        /// <returns> Список журналов </returns>
        Task<List<HabitDiary>> GetPagedAsync(HabitDiaryFilterModel filterModel, CancellationToken cancellationToken);


        /// <summary>
        /// Получить дневники по гуиду владельца
        /// </summary>
        /// <param name="id"> Гуид владельца</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список дневников</returns>
        Task<List<HabitDiary>> GetAllByDiaryOwnerIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

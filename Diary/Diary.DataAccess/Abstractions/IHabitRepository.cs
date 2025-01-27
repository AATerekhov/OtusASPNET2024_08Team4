using Diary.Core.Abstractions;
using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Abstractions
{
    public interface IHabitRepository : IRepository<Habit>
    {
        /// <summary>
        /// Получение всех привычек дневника
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список привычек конкретного дневника</returns>
        Task<List<Habit>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

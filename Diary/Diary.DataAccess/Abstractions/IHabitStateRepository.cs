using Diary.Core.Abstractions;
using Diary.Core.Domain.Habits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Abstractions
{
    public interface IHabitStateRepository : IRepository<HabitState>
    {
        /// <summary>
        /// Получение всех состояний привычки
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Список состояний конкретной привычки</returns>
        Task<List<HabitState>> GetAllByHabitIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

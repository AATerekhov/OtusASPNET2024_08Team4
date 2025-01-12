using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.JournalOwner;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IHabitService
    {
        /// <summary>
        /// Получить привычку 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Привычка </returns>
        Task<Habit> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать привычку
        /// </summary>
        /// <param name="createHabitDto"> дто создаваемой привычки. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<Habit> CreateAsync(CreateHabitDto createHabitDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить привычку
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="editHabitDto"> дто редактируемой привычки. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<Habit> UpdateAsync(Guid id, EditHabitDto editHabitDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить привычку
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все привычки
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список привычек</returns>
        Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить все привычки дневника
        /// </summary>
        /// <param name="id"> Гуид дневника</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список привычек дневника</returns>
        Task<ICollection<Habit>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

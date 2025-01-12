using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.HabitState;
using Diary.Core.Domain.Habits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IHabitStateService
    {
         /// <summary>
         /// Получить состояние привычки
         /// </summary>
         /// <param name="id"> Идентификатор. </param>
         /// <param name="cancellationToken"> cancellationToken </param>
         /// <returns> Привычка </returns>
        Task<HabitState> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать состояние привычки
        /// </summary>
        /// <param name="createHabitStateDto"> дто создаваемого состояния привычки. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitState> CreateAsync(CreateHabitStateDto createHabitStateDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить состояние привычки
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="editHabitDto"> дто редактируемого состояния привычки. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitState> UpdateAsync(Guid id, EditHabitStateDto editHabitStateDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить состояние привычки
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все состояния привычек
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список состояний привычек</returns>
        Task<List<HabitState>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить все состояния конкретной привычки
        /// </summary>
        /// <param name="id"> Гуид привычки</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список состояний конкретной привычки</returns>
        Task<ICollection<HabitState>> GetAllByHabitIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IHabitDiaryService
    {
        /// <summary>
        /// Получить дневник по гуиду
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>дневник</returns>
        Task<HabitDiary> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать дневник 
        /// </summary>
        /// <param name="createOrEditJournalDto"> дто редактируемого дневник. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitDiary> CreateAsync(CreateOrEditHabitDiaryDto createOrEditJournalDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить дневник
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="createOrEditJournalDto"> дто редактируемого дневника </param>
        /// <param name="cancellationToken"> CancellationToken</param>
        Task<HabitDiary> UpdateAsync(Guid id, CreateOrEditHabitDiaryDto createOrEditJournalDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить дневник
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все дневники
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список дневников</returns>
        Task<List<HabitDiary>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список дневников</returns>
        Task<ICollection<HabitDiary>> GetPagedAsync(HabitDiaryFilterDto filterDto, CancellationToken cancellationToken);
    }
}

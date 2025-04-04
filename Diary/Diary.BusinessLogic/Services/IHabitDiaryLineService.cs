using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IHabitDiaryLineService
    {
        /// <summary>
        /// Получить строку дневника по гуиду
        /// </summary>
        /// <param name="id"> Гуид строки </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>строка дневника</returns>
        Task<HabitDiaryLine> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все строки дневника по гуиду дненвика
        /// </summary>
        /// <param name="id"> Гуид дневника</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список строк дневника</returns>
        Task<ICollection<HabitDiaryLine>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать строку дневника
        /// </summary>
        /// <param name="createOrEditDiaryLineDto"> дто редактируемой строки дневника. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitDiaryLine> CreateAsync(CreateHabitDiaryLineDto createOrEditDiaryLineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить строку дневника
        /// </summary>
        /// <param name="id"> Гуид строки </param>
        /// <param name="editDiaryLineDto"> дто редактируемой строки дневника </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitDiaryLine> UpdateAsync(Guid id, EditHabitDiaryLineDto editDiaryLineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить строку дневника
        /// </summary>
        /// <param name="id"> Гуид  </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все строки дневников
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список строк дневников</returns>
        Task<List<HabitDiaryLine>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список строк дневников</returns>
        Task<ICollection<HabitDiaryLine>> GetPagedAsync(HabitDiaryLineFilterDto filterDto, CancellationToken cancellationToken);
    }
}

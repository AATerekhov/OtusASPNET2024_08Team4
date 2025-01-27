using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.JournalOwner;
using Diary.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IHabitDiaryOwnerService
    {
        /// <summary>
        /// Получить владельца дневника
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> владелец дневника </returns>
        Task<HabitDiaryOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать владельца дневника
        /// </summary>
        /// <param name="createOrEditDiaryOwnerDto"> дто редактируемого владельца дневника. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitDiaryOwner> CreateAsync(CreateOrEditHabitDiaryOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить владельца дневника
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="createOrEditDiaryOwnerDto"> дто редактируемого владельца дневника. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<HabitDiaryOwner> UpdateAsync(Guid id, CreateOrEditHabitDiaryOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить владельца дневника
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить всех владельцев дневника
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список владельцев дневника</returns>
        Task<List<HabitDiaryOwner>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список владельцев дневника. </returns>
        Task<ICollection<HabitDiaryOwner>> GetPagedAsync(HabitDiaryOwnerFilterDto filterDto, CancellationToken cancellationToken);
    }
}

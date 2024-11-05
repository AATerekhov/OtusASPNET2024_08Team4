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
    public interface IJournalOwnerService
    {
        /// <summary>
        /// Получить владельца дневника
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> владелец дневника </returns>
        Task<JournalOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать владельца дневника
        /// </summary>
        /// <param name="creatingCustomerModel"> дто редактируемого владельца дневника. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<JournalOwner> CreateAsync(CreateOrEditJournalOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить владельца дневника
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCustomerModel"> дто редактируемого владельца дневника. </param>
        Task<JournalOwner> UpdateAsync(Guid id, CreateOrEditJournalOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken);

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
        Task<List<JournalOwner>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterModel"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список владельцев дневника. </returns>
        Task<ICollection<JournalOwner>> GetPagedAsync(JournalOwnerFilterDto filterDto, CancellationToken cancellationToken);
    }
}

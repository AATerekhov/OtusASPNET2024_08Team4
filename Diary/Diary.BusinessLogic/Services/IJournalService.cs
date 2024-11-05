using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services
{
    public interface IJournalService
    {
        /// <summary>
        /// Получить журнал юзера
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> журнал юзера </returns>
        Task<Journal> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать журнал юзера
        /// </summary>
        /// <param name="creatingCustomerModel"> дто редактируемого журнала. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<Journal> CreateAsync(CreateOrEditJournalDto createOrEditJournalDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить журнал юзера
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCustomerModel"> дто редактируемого журнала юзерf </param>
        Task<Journal> UpdateAsync(Guid id, CreateOrEditJournalDto createOrEditJournalDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить журнал юзера
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все журналы юзера
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список журналов юзеров</returns>
        Task<List<Journal>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterModel"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список журналов юзера </returns>
        Task<ICollection<Journal>> GetPagedAsync(JournalFilterDto filterDto, CancellationToken cancellationToken);
    }
}

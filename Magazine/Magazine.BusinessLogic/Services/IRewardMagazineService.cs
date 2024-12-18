using Magazine.BusinessLogic.Models.RewardMagazine;
using Magazine.Core.Domain.Magazines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services
{
    public interface IRewardMagazineService
    {
        /// <summary>
        /// Получить журнал наград по гуиду
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>дневник</returns>
        Task<RewardMagazine> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать журнал наград
        /// </summary>
        /// <param name="createOrEditMagazineDto"> дто редактируемого журнала наград</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<RewardMagazine> CreateAsync(CreateRewardMagazineDto createOrEditMagazineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить  журнал наград
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="editMagazineDto"> дто редактируемого журнала наград</param>
        /// <param name="cancellationToken"> CancellationToken</param>
        Task<RewardMagazine> UpdateAsync(Guid id, EditRewardMagazineDto editMagazineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить журнал наград
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все журналы наград
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список дневников</returns>
        Task<List<RewardMagazine>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список журналов наград</returns>
        Task<ICollection<RewardMagazine>> GetPagedAsync(RewardMagazineFilterDto filterDto, CancellationToken cancellationToken);

        /// <summary>
        /// Получить журналы наград по гуиду владельца
        /// </summary>
        /// <param name="id"> Гуид владельца</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список журналов наград</returns>
        Task<List<RewardMagazine>> GetAllByMagazineOwnerIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

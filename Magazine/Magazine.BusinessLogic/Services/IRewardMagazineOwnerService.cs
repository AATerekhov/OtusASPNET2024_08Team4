using Magazine.BusinessLogic.Models.RewardMagazineOwner;
using Magazine.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services
{
    public interface IRewardMagazineOwnerService
    {
        /// <summary>
        /// Получить владельца журнала наград
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> владелец журнала наград </returns>
        Task<RewardMagazineOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать владельца журнала наград
        /// </summary>
        /// <param name="createOrEditMagazineOwnerDto"> дто редактируемого владельца журнала наград. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<RewardMagazineOwner> CreateAsync(CreateOrEditRewardMagazineOwnerDto createOrEditMagazineOwnerDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить владельца журнала наград
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="createOrEditMagazineOwnerDto"> дто редактируемого владельца журнала наград </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<RewardMagazineOwner> UpdateAsync(Guid id, CreateOrEditRewardMagazineOwnerDto createOrEditMagazineOwnerDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить владельца журнала наград
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить всех владельцев журналов наград
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список владельцев журналов наград</returns>
        Task<List<RewardMagazineOwner>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список владельцев журналов наград. </returns>
        Task<ICollection<RewardMagazineOwner>> GetPagedAsync(RewardMagazineOwnerFilterDto filterDto, CancellationToken cancellationToken);
    }
}

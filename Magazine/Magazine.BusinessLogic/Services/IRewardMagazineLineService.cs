using Magazine.BusinessLogic.Models.RewardMagazineLine;
using Magazine.Core.Domain.Magazines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services
{
    public interface IRewardMagazineLineService
    {
        /// <summary>
        /// Получить строку журнала наград по гуиду
        /// </summary>
        /// <param name="id"> Гуид строки </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>строка журнала наград</returns>
        Task<RewardMagazineLine> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все строки журнала наград по гуиду журнала
        /// </summary>
        /// <param name="id"> Гуид дневника</param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>список строк журнала наград</returns>
        Task<ICollection<RewardMagazineLine>> GetAllByMagazineIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать строку журнала наград
        /// </summary>
        /// <param name="createOrEditMagazineLineDto"> дто редактируемой строки журнала наград. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<RewardMagazineLine> CreateAsync(CreateOrEditRewardMagazineLineDto createOrEditMagazineLineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить строку дневника
        /// </summary>
        /// <param name="id"> Гуид строки </param>
        /// <param name="createOrEditMagazineLineDto"> дто редактируемой строки журнала наград </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<RewardMagazineLine> UpdateAsync(Guid id, CreateOrEditRewardMagazineLineDto createOrEditMagazineLineDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить строку журнала наград
        /// </summary>
        /// <param name="id"> Гуид  </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все строки журналов наград
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список строк журналов наград</returns>
        Task<List<RewardMagazineLine>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> дто фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список строк журналов наград</returns>
        Task<ICollection<RewardMagazineLine>> GetPagedAsync(RewardMagazineLineFilterDto filterDto, CancellationToken cancellationToken);
    }
}

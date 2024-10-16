using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Abstractions
{
    public interface IRepository<T> where T : BaseEntity

    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking);
        IQueryable<T> GetAll(bool asNoTracking);
        Task<T> GetByIdAsync(CancellationToken cancellationToken, Guid id);
        Task<T> AddAsync(CancellationToken cancellationToken,T entity);

        bool Delete(Guid id);

        void Update(T entity);

        Task AddRangeAsync(CancellationToken cancellationToken, ICollection<T> entities);

        Task SaveChangesAsync(CancellationToken cancellationToken);

        void SaveChanges();
    }
}

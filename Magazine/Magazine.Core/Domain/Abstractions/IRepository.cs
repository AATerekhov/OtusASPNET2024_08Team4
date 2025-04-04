using Magazine.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Core.Domain.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking, Expression<Func<T, bool>> filter = null, string includes = null);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken, string includes = null);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        bool Delete(T entity);

        void Update(T entity);

        Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);

        void SaveChanges();
    }
}

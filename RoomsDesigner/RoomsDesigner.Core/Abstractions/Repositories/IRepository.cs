using RoomsDesigner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RoomsDesigner.Core.Abstractions.Repositories
{
	public interface IRepository<T, TId> where T : IEntity<TId>
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includes = null, bool asNoTracking = false);

		Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, string includes = null, bool asNoTracking = false);

		Task<T> AddAsync(T entity);

		void Update(T entity);

		bool Delete(T entity);

		Task SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}

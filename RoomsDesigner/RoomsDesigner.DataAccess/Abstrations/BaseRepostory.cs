using Microsoft.EntityFrameworkCore;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RoomsDesigner.DataAccess.Abstrations
{
	public abstract class BaseRepostory<T, TId> : IRepository<T, TId> where T : class, IEntity<TId>
	{
		private readonly DbSet<T> _entitySet;
		protected readonly DbContext Context;

		private static readonly char[] IncludeSeparator = [','];

		protected BaseRepostory(DbContext context)
		{
			Context = context;
			_entitySet = Context.Set<T>();
		}

		public virtual async Task<List<T>> GetAllAsync(
			Expression<Func<T, bool>> filter = null,
			string includes = null,
			bool asNoTracking = false)
		{
			IQueryable<T> query = _entitySet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includes != null && includes.Any())
			{
				foreach (var includeEntity in includes.Split(IncludeSeparator, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeEntity);
				}
			}

			if (asNoTracking)
			{
				query = query.AsNoTracking();
			}

			return await query.ToListAsync();
		}

		public virtual async Task<T> GetByIdAsync(
			Expression<Func<T, bool>> filter,
			string includes = null,
			bool asNoTracking = false)
		{
			IQueryable<T> query = _entitySet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includes != null && includes.Any())
			{
				foreach (var includeEntity in includes.Split(IncludeSeparator, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeEntity);
				}
			}

			if (asNoTracking)
			{
				query = query.AsNoTracking();
			}

			return await query.SingleOrDefaultAsync();
		}

		public virtual async Task<T> AddAsync(T entity)
			=> (await _entitySet.AddAsync(entity)).Entity;

		public virtual void Update(T entity)
			=> Context.Entry(entity).State = EntityState.Modified;

		public bool Delete(T entity)
		{
			if (entity == null)
			{
				return false;
			}
			Context.Entry(entity).State = EntityState.Deleted;
			return true;
		}

		public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
			=> await Context.SaveChangesAsync(cancellationToken);
	}
}

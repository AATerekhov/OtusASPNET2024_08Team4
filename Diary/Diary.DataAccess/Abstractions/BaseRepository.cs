using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diary.Core.Abstractions;
using Diary.Core.Domain.BaseTypes;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Diary.DataAccess.Abstractions
{
    public abstract class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T>    _entitySet;

        private static readonly char[] IncludeSeparator = [','];
        protected BaseRepository(DbContext context)
        {
            Context    = context;
           _entitySet = Context.Set<T>();
        }

        /// <summary>
        /// Получить сущность по Id.
        /// </summary>
        /// <param name="id">Id сущности.</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <param name="filter">фильтер</param>
        /// <returns> Cущность. </returns>
        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken, string includes = null)
        {
            IQueryable<T> query = _entitySet;

            if (includes != null && includes.Any())
            {
                foreach (var includeEntity in includes.Split(IncludeSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeEntity);
                }
            }

            return await query.AsNoTracking().Where(x => x.Id == id).FirstAsync(cancellationToken);
        }

        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> IQueryable массив сущностей. </returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool asNoTracking = false)
        {
            IQueryable<T> query = _entitySet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }


        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <param name="filter">фильтр</param>
        /// <returns> Список сущностей. </returns>
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false, Expression<Func<T, bool>> filter = null, string includes = null)
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

        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> токен отмены</param>
        /// <returns> Добавленная сущность. </returns>
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            return (await _entitySet.AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Добавить в базу массив сущностей.
        /// </summary>
        /// <param name="entities"> Массив сущностей. </param>
        /// <param name="cancellationToken"> токен отмены</param>
        public virtual async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }
            await _entitySet.AddRangeAsync(entities);
        }


        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }


        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="id"> Id удалённой сущности. </param>
        /// <returns> Была ли сущность удалена. </returns>
        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                return false;
            }

            Context.Entry(entity).State = EntityState.Deleted;

            return true;
        }


        /// <summary>
        /// Удалить сущности.
        /// </summary>
        /// <param name="entities"> Коллекция сущностей для удаления. </param>
        /// <returns> Была ли операция завершена успешно. </returns>
        public virtual bool DeleteRange(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            _entitySet.RemoveRange(entities);
            return true;
        }

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// получение записей по условиям
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// получение записи по условиям
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diary.Core.Abstractions;
using Diary.Core.Domain.BaseTypes;

namespace Diary.DataAccess.Abstractions
{
    public abstract class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T>    _entitySet;

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
        /// <returns> Cущность. </returns>
        public virtual async Task<T> GetByIdAsync(CancellationToken cancellationToken, Guid id)
        {
            return await _entitySet.FindAsync(id);
        }

        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> IQueryable массив сущностей. </returns>
        public virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? _entitySet.AsNoTracking() : _entitySet;
        }


        /// <summary>
        /// Запросить все сущности в базе.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> Список сущностей. </returns>
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await GetAll().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> токен отмены</param>
        /// <returns> Добавленная сущность. </returns>
        public virtual async Task<T> AddAsync(CancellationToken cancellationToken, T entity)
        {
            return (await _entitySet.AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Добавить в базу массив сущностей.
        /// </summary>
        /// <param name="cancellationToken"> токен отмены</param>
        /// <param name="entities"> Массив сущностей. </param>
        public virtual async Task AddRangeAsync(CancellationToken cancellationToken, ICollection<T> entities)
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
        public virtual bool Delete(Guid id)
        {
            var obj = _entitySet.Find(id);
            if (obj == null)
            {
                return false;
            }
            _entitySet.Entry(obj).State = EntityState.Deleted;

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
    }
}

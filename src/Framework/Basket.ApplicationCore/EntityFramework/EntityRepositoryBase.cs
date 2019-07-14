using Basket.ApplicationCore.Abstract;
using Basket.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Basket.ApplicationCore.EntityFramework
{
    public abstract class EntityRepositoryBase<TEntity, TPrimaryKey, TContext> : IGenericRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        #region Select

        public virtual IQueryable<TEntity> GetAll()
        {
            using var context = new TContext();
            return context.Set<TEntity>();
        }

        public virtual IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? GetAll().ToList() : GetAll().Where(filter).ToList();
        }
        public virtual async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? await GetAll().ToListAsync() : await GetAll().Where(filter).ToListAsync();
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
        public virtual TEntity GetById(TPrimaryKey id)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Find(id);
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        #endregion
        #region  Insert

        public virtual void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        #endregion

        #region Delete

        public virtual void Delete(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual void DeleteById(TPrimaryKey id)
        {
            using var context = new TContext();
            var entity = GetById(id);
            Delete(entity);

        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsyncById(TPrimaryKey id)
        {
            using var context = new TContext();
            var entity = GetById(id);
            await DeleteAsync(entity);

        }


        #endregion

        #region Update

        public virtual void Update(TEntity entity, TPrimaryKey id)
        {
            using var context = new TContext();
            var existedEntity = GetById(id);
            if (existedEntity != null)
            {
                context.Entry(existedEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity, TPrimaryKey id)
        {
            using var context = new TContext();
            var existedEntity = GetByIdAsync(id);
            if (existedEntity != null)
            {
                context.Entry(existedEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
            }
        }

        #endregion

        public Task<int> CountOfList()
        {
            using var context = new TContext();
            return context.Set<TEntity>().CountAsync();
        }


    }
}

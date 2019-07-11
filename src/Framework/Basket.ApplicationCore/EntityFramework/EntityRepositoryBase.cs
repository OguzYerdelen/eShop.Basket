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
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var newEntity = context.Entry(entity);
                newEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var newEntity = context.Entry(entity);
                newEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                
            }
        }

        public Task<int> CountOfList()
        {
            using (var context = new TContext())
            {

                return context.Set<TEntity>().CountAsync();

            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TPrimaryKey Id)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().AsNoTracking().ToList();
                }
                else
                {
                    return context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
                }
            }
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

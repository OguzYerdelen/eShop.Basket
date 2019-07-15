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

        public virtual IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter=null)
        {

            using var context = new TContext();
            return filter==null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
        public virtual TEntity GetById(TPrimaryKey id)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Find(id);
        }
        
        public virtual void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

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

        public virtual void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public virtual int Count()
        {
            using var context = new TContext();
            return context.Set<TEntity>().Count();
        }

        
 


    }
}

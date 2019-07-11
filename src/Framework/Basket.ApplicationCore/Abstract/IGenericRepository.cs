using Basket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basket.ApplicationCore.Abstract
{
    public interface IGenericRepository<TEntity, in TPrimaryKey> where TEntity : class, IEntity, new()
    {
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(TPrimaryKey Id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(TPrimaryKey id);
        Task<int> CountOfList();
        Task AddAsync(TEntity entity);

    }
}

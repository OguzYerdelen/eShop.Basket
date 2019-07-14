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
        #region select

        IQueryable<TEntity> GetAll();
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(TPrimaryKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(TPrimaryKey id);
       

        #endregion

        #region add
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        #endregion

        #region Delete

        void Delete(TEntity entity);
        void DeleteById(TPrimaryKey id);

        Task DeleteAsync(TEntity entity);
        Task DeleteAsyncById(TPrimaryKey id);


        #endregion

        #region Update

        void Update(TEntity entity, TPrimaryKey id);
        Task UpdateAsync(TEntity entity, TPrimaryKey id);


        #endregion

        #region aggregate

        Task<int> CountOfList();

        #endregion

        
       
        
        

    }
}

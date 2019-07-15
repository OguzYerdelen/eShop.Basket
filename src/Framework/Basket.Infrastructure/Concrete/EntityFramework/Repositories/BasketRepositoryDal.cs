using System;
using System.Linq;
using Basket.ApplicationCore.EntityFramework;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class BasketRepositoryDal : EntityRepositoryBase<Domain.Concrete.Basket, int, EShopContext>, IBasketRepositoryDal
    {
       
        public void AddToBasket(Domain.Concrete.Basket entity)
        {
            using (var context = new EShopContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (CheckStock(entity.ProductId, entity.CountOfProduct))
                        {
                            context.Baskets.Add(entity);
                            context.SaveChanges();
                            transaction.Commit();
                        }
                       
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Transaction failed:",e);
                    }
                }
            }


        }
        

        private bool CheckStock(int productId, int expectedUnits)
        {
            using (var context = new EShopContext())
            {
                var product = context.Products.SingleOrDefault(x => x.Id == productId);
              

                var diffrenceOfCount = product.UnitsInStock - expectedUnits;

                if (diffrenceOfCount > 0)
                {
                    product.UnitsInStock = diffrenceOfCount;
                    context.Update(product);
                    context.SaveChanges();
                    return true;
                }
                return false;

            }
        }
    }
}
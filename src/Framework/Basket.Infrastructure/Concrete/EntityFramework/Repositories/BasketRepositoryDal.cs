using System;
using System.ComponentModel.Design;
using System.Linq;
using Basket.ApplicationCore.EntityFramework;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class BasketRepositoryDal : EntityRepositoryBase<Domain.Concrete.Basket, int, EShopContext>, IBasketRepositoryDal
    {
        public void AddProductToBasket(Domain.Concrete.Basket entity)
        {
            using (var context = new EShopContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (!CheckUserIsInDb(entity.UserId))
                        {
                            if (CheckStock(entity.ProductId, entity.CountOfProduct))
                            {
                                context.Baskets.Add(entity);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("Expected product number more than current product number");
                            }
                        }
                        else
                        {
                            if (CheckStock(entity.ProductId, entity.CountOfProduct))
                            {
                                var existedUser = context.Baskets.SingleOrDefault(x =>
                                    x.ProductId == entity.ProductId && x.UserId == entity.UserId);
                                existedUser.CountOfProduct += entity.CountOfProduct;
                                context.Baskets.Update(existedUser);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("Expected product number more than current product number");
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Transaction failed:", e);
                    }
                }
            }
        }
        public void RemoveProductFromBasket(Domain.Concrete.Basket entity)
        {
            using (var context = new EShopContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (CheckUserIsInDb(entity.UserId))
                        {
                            var existedProduct = context.Baskets.SingleOrDefault(x =>
                                x.UserId == entity.UserId && x.ProductId == entity.ProductId);
                            if (entity.CountOfProduct == 0)
                            {
                                context.Baskets.Remove(existedProduct);
                                context.SaveChanges();
                            }
                            else
                            {
                                existedProduct.CountOfProduct -= entity.CountOfProduct;
                                if (existedProduct.CountOfProduct<0)
                                {
                                    throw new Exception("Existed product number cant be less than 0");
                                }
                                context.Baskets.Update(existedProduct);
                                context.SaveChanges();
                                var product = context.Products.SingleOrDefault(x => x.Id == entity.ProductId);
                                product.UnitsInStock += entity.CountOfProduct;
                                context.Products.Update(product);
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            throw new Exception("There is not exist any user");
                        }

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Transaction failed:", e);
                    }
                }
            }
        }
        private bool CheckUserIsInDb(int id)
        {
            using (var context = new EShopContext())
            {
                var userExist = context.Baskets.Any(x => x.UserId == id);
                return userExist == true ? true : false;
            }
        }
        private bool CheckStock(int productId, int expectedUnits)
        {
            using (var context = new EShopContext())
            {
                var product = context.Products.SingleOrDefault(x => x.Id == productId);
                decimal diffrenceOfCount = product.UnitsInStock - expectedUnits;

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
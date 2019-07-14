using System;
using System.Collections.Generic;
using System.Text;
using Basket.ApplicationCore.EntityFramework;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class ProductRepositoryDal : EntityRepositoryBase<Product, int, EShopContext>, IProductRepositoryDal
    {
    }
}

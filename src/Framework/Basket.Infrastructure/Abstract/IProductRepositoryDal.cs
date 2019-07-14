using System;
using System.Collections.Generic;
using System.Text;
using Basket.ApplicationCore.Abstract;
using Basket.Domain.Concrete;

namespace Basket.Infrastructure.Abstract
{
    public interface IProductRepositoryDal:IGenericRepository<Product,int>
    {
    }
}

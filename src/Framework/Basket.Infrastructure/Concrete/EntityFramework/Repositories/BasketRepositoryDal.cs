using Basket.ApplicationCore.EntityFramework;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class BasketRepositoryDal : EntityRepositoryBase<Domain.Concrete.Basket, int, EShopContext>, IBasketRepositoryDal
    {
        
    }
}
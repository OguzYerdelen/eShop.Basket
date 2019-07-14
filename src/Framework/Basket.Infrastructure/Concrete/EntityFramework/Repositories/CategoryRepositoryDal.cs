using Basket.ApplicationCore.EntityFramework;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class CategoryRepositoryDal : EntityRepositoryBase<Category, int, EShopContext>,ICategoryRepositoryDal
    {
    }
}

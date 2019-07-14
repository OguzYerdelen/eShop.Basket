using Basket.ApplicationCore.Abstract;
using Basket.Domain.Concrete;

namespace Basket.Infrastructure.Abstract
{
    public interface ICategoryRepositoryDal: IGenericRepository<Category, int>
    {
        
    }
}
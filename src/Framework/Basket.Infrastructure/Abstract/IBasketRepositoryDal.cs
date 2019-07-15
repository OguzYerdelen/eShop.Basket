using Basket.ApplicationCore.Abstract;
using Basket.Domain.Concrete;

namespace Basket.Infrastructure.Abstract
{
    public interface IBasketRepositoryDal: IGenericRepository<Domain.Concrete.Basket, int>
    {

        void AddToBasket(Domain.Concrete.Basket entity);

    }
}
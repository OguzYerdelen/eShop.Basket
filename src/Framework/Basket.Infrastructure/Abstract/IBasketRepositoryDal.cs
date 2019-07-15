using Basket.ApplicationCore.Abstract;
using Basket.Domain.Concrete;

namespace Basket.Infrastructure.Abstract
{
    public interface IBasketRepositoryDal: IGenericRepository<Domain.Concrete.Basket, int>
    {

        void AddProductToBasket(Domain.Concrete.Basket entity);
        void RemoveProductFromBasket(Domain.Concrete.Basket entity);

    }
}
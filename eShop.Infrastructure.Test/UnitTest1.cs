using Basket.Infrastructure.Concrete.EntityFramework.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Basket.Domain.Concrete;
using Xunit;

namespace eShop.Infrastructure.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var newUser = new  ProductDalMock();
            var user = new User();
            user.Name = "Oguz";
            user.Surname = "Yerdelen";
            await newUser.AddAsync(user);
            var a = newUser.GetList().Count;
            Assert.Equal(4,a);
        }
    }
    public class ProductDalMock : UserRepositoryDal
    {

    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Repositories;
using Xunit;

namespace eShop.Infrastructure.Test
{
    public class UnitTest1
    {
        [Fact]
        public  void Test1()
        {
            var t = new UserRepositoryDal();
            var person = t.GetById(1);
            var user = new User()
            {  Id =  person.Id,
                Name = "Oguz",
                Surname = "Yerdelen55252"
            };
            
            t.Update(user);
            var o = t.GetById(1).Surname;
            Assert.Equal("Yerdelen55252", o);
        }

        [Fact]
        public void Count()
        {
            var t = new UserRepositoryDal();
            
            Assert.Equal(1, t.Count());
        }

        [Fact]
        public void add()
        {
            var t = new UserRepositoryDal();
            var user = new User()
            {
                
                Name = "Oguz",
                Surname = "Yerdelen552524242"
            };
            t.Add(user);

            Assert.Equal(1, t.Count());
        }


        [Fact]
        public void Delete()
        {
            var t = new UserRepositoryDal();
           
            t.DeleteById(2);

            Assert.Equal(1, t.Count());
        }

        [Fact]
        public void addtt()
        {
            var t = new BasketRepositoryDal();
            var user = new Basket.Domain.Concrete.Basket()
            {
                CountOfProduct = 250,
                ProductId = 1,
                UserId = 2

            };
            t.AddToBasket(user);
            Assert.Equal(2, t.Count());
        }
    


    }

}

using Basket.ApplicationCore.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Basket.Domain.Concrete;
using Basket.Infrastructure.Abstract;
using Basket.Infrastructure.Concrete.EntityFramework.Context;

namespace Basket.Infrastructure.Concrete.EntityFramework.Repositories
{
    public class UserRepositoryDal: EntityRepositoryBase<User,int,EShopContext>,IUserRepositoryDal
    {
        
    }
}

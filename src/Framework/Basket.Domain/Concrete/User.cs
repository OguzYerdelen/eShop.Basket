using System;
using System.Collections.Generic;
using System.Text;
using Basket.ApplicationCore.Entities;
using Basket.Domain.Abstract;

namespace Basket.Domain.Concrete
{
    public class User : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

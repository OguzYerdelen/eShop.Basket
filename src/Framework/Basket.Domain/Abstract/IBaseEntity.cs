using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain.Abstract
{
    interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}

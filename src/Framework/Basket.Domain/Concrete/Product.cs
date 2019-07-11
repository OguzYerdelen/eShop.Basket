using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Basket.ApplicationCore.Entities;
using Basket.Domain.Abstract;

namespace Basket.Domain.Concrete
{
    public class Product : FullAuditedEntity<int>, IEntity
    {
        public Product()
        {

        }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}

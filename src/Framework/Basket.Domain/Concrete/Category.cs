using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Basket.ApplicationCore.Entities;
using Basket.Domain.Abstract;

namespace Basket.Domain.Concrete
{
    public class Category :FullAuditedEntity<int>, IEntity
    {
        public Category()
        {
            Products = new List<Product>();
            CreatedDate = DateTime.Now;
        }

        [StringLength(50)]
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}

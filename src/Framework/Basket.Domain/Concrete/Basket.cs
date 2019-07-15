using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Basket.ApplicationCore.Entities;
using Basket.Domain.Abstract;

namespace Basket.Domain.Concrete
{
    public class Basket : BaseEntity<int>,IEntity
    {
        [ForeignKey("UserId"), Column(Order = 2)]
        public User User { get; set; }
        [ForeignKey("ProductId"), Column(Order = 2)]
        public Product Product { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CountOfProduct { get; set; }

    
    }
}

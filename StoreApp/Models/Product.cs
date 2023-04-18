using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    [Table("ProductTbl")]
    public class Product
    {
        [Key]
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProdDesc { get; set; }
        public decimal Price { get; set; }
        public string photopath { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        [ForeignKey("Category")]
        public Int64 CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<UserOrderDetails> UserOrderDetails { get; set; }
        public virtual List<Cart> Carts { get; set; }

    }
}

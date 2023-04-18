using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    [Table("UserOrderDetailsTbl")]
    public class UserOrderDetails
    {
        [Key]
        public Int64 UserOrderDetID { get; set; }
        [ForeignKey("UserOrder")]
        public Int64 UserOrderID { get; set; }
        public virtual UserOrder UserOrder { get; set; }
        [ForeignKey("Product")]
        public Int64 ProductID { get; set; }
        public virtual Product Product { get; set; }
        public Int64 Qty { get; set; }
        public decimal Price { get; set; }
    }
}

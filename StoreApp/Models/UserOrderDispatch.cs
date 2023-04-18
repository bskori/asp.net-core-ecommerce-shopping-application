using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    [Table("UserOrderDispatchTbl")]
    public class UserOrderDispatch
    {
        [Key]
        public Int64 UserOrderDispatchID { get; set; }
        [ForeignKey("UserOrder")]
        public Int64 UserOrderID { get; set; }
        public virtual UserOrder UserOrder { get; set; }
        [ForeignKey("DispatchAgency")]
        public Int64 DispatchAgencyID { get; set; }
        public virtual DispatchAgency DispatchAgency { get; set; }
        public Int64 DocketNo { get; set; }

        public DateTime DispatchDate { get; set; }
        public DateTime ExpectedReachDate { get; set; }
    }
}

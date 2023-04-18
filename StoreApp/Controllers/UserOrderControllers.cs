using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.CustFilter;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    [UserAuth]
    public class UserOrderControllers : Controller
    {
        StoreContext cntx;
        public UserOrderControllers(StoreContext stemp)
        {
            this.cntx = stemp;
        }
        public IActionResult Index()
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var uordRec = this.cntx.UserOrders.Where(p => p.UserID == userid);
            return View(uordRec.ToList());
        }

        public IActionResult ViewDispatchDetails(Int64 Id)
        {
            var dpRec = this.cntx.UserOrderDispatches.Where(p => p.UserOrderID == Id);
            if (dpRec.Any())
            {
                ViewBag.Message="Order Dispatched!";
                return View(dpRec.ToList());
            }
            else
            {
                ViewBag.Message="Order Not Dispatched!";
                return View();
            }
           
        }
    }
}

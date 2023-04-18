using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.CustFilter;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Areas.Store.Controllers
{
    [Area("Store")]
    [StoreAuth]
    public class OrderControllers : Controller
    {
        StoreContext cntx;
        public OrderControllers(StoreContext stemp)
        {
            this.cntx = stemp;
        }
        public IActionResult Index()
        {
            return View(this.cntx.UserOrders.ToList());
        }

        [HttpGet]
        public IActionResult DispatchOrder(Int64 Id)
        {
            var rec = this.cntx.UserOrders.Find(Id);
            return View(rec);
        }

        [HttpGet]
        public IActionResult ExecuteDispatchOrder(Int64 Id)
        {
            ViewBag.DispatchAgencyID = new SelectList(this.cntx.DispatchAgencies.ToList(), "DispatchAgencyID", "DispatchAgencyName");
            ViewBag.OrderID = Id;
            var uord = this.cntx.UserOrders.Find(Id);
            ViewBag.Name = uord.User.FirstName;
            return View();
        }

        [HttpPost]
        public IActionResult ExecuteDispatchOrder(UserOrderDispatch rec)
        {
            if (ModelState.IsValid)
            {
                rec.DispatchDate = DateTime.Now;
                this.cntx.UserOrderDispatches.Add(rec);
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
    }
}

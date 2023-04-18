using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.CustFilter;
using StoreApp.Models;
using StoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    [UserAuth]
    public class CartControllers : Controller
    {
        StoreContext cntx;
        public CartControllers(StoreContext stemp)
        {
            this.cntx = stemp;
        }

        public IActionResult AddToCart(Int64 Id)
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            Product prodrec = this.cntx.Products.Find(Id);
            var ucart = this.cntx.Carts.SingleOrDefault(p => p.UserID == userid && p.ProductID == Id);

            if(ucart != null)
            {
                ucart.Qty++;
                this.cntx.SaveChanges();
            }
            else
            {
                Cart newcart = new Cart();
                newcart.Price = prodrec.Price;
                newcart.ProductID = Id;
                newcart.Qty = 1;
                newcart.UserID = userid;
                this.cntx.Carts.Add(newcart);
                this.cntx.SaveChanges();

            }
                return RedirectToAction("GetProduct", "Home", new {Id = prodrec.CategoryID });

        }

        public IActionResult GetCart()
        {
            ViewBag.PaymentMode = new SelectList(new string[] {"Cash On Delivery", "Card/NetBanking", "UPI" });

            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var cart = this.cntx.Carts.Where(p => p.UserID == userid);

            return View(cart.ToList());
        }

        public IActionResult DeleteCart(Int64 Id)
        {
            var rec = this.cntx.Carts.Find(Id);
            this.cntx.Carts.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("GetCart");
        }

        public IActionResult MakePayment(string PaymentMode)
        {
            if(PaymentMode == "Cash On Delivery")
            {
                return RedirectToAction("PlaceOrder", new { flag = false });
            }
            else
            {
                return RedirectToAction("PaymentGateway");
            }
        }

        [HttpGet]
        public IActionResult PaymentGateway()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentGateway(PaymentGatewayVM rec)
        {
            return RedirectToAction("PlaceOrder", new { flag = true });
        }

        public IActionResult PlaceOrder(bool flag)
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var cart = this.cntx.Carts.Where(p => p.UserID == userid);

            UserOrder uord = new UserOrder();
            uord.IsPaid = flag;
            uord.OrderDateTime = DateTime.Now;
            uord.UserID = userid;

            foreach(var temp in cart)
            {
                UserOrderDetails uodet = new UserOrderDetails();
                uodet.Price = temp.Price;
                uodet.ProductID = temp.ProductID;
                uodet.Qty = temp.Qty;
                uord.UserOrderDetails.Add(uodet);
            }

            this.cntx.UserOrders.Add(uord);
            this.cntx.SaveChanges();

            var newcart = this.cntx.Carts.Where(p => p.UserID == userid);
            foreach(var temp in newcart)
            {
                this.cntx.Carts.Remove(temp);
            }

            this.cntx.SaveChanges();

            ViewBag.Message = "Order placed Successfully!";
            return View();
        }



        
    }
}

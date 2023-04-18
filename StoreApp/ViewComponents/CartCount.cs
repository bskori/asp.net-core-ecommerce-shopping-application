using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewComponents
{
    public class CartCount:ViewComponent
    {
        StoreContext cntx;
        public CartCount(StoreContext stemp)
        {
            this.cntx = stemp;
        }

        public IViewComponentResult Invoke()
        {
            Int64 userid = Convert.ToInt64(HttpContext.Session.GetString("UserID"));
            var cnt = this.cntx.Carts.Count(p => p.UserID == userid);
            return View(cnt);
        }
    }
}

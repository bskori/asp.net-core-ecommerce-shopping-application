using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoreApp.CustFilter;
using StoreApp.Models;
using StoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Areas.Store.Controllers
{
    [Area("Store")]
    public class StoreHome : Controller
    {
        StoreContext cntx;
        public StoreHome(StoreContext stemp)
        {
            this.cntx = stemp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM rec)
        {
            if (ModelState.IsValid)
            {
                Int64 logStrid = Convert.ToInt64(HttpContext.Session.GetString("StoreID"));
                var urec = this.cntx.Stores.SingleOrDefault(p => p.StoreID == logStrid);

                if (urec.Password == rec.OldPassword)
                {
                    urec.Password = rec.NewPassword;
                    this.cntx.SaveChanges();
                    ViewBag.Message = "Password Changed Succesfully!";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("","Invalid Old Password!");
                    return View(rec);
                }
            }
            return View(rec);
        }
    }
}

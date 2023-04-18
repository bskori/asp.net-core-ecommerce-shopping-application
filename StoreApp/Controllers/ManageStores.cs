using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class ManageStores : Controller
    {
        StoreContext cntx;
        public ManageStores(StoreContext temp)
        {
            this.cntx = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult doLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult doLogin(LoginVM rec)
        {
            if (ModelState.IsValid)
            {
                Store srec = this.cntx.Stores.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if (srec != null)
                {
                    HttpContext.Session.SetString("SchoolID", srec.StoreID.ToString());
                    return RedirectToAction("Index", "StoreHome", new { area = "Store" });
                }
                ModelState.AddModelError("", "Invalid Email ID or Password");
                return View(rec);
            }
            return View(rec);

        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("doLogin");
        }
    }
}  
    


using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        StoreContext cc;
        public HomeController(StoreContext stemp)
        {
            this.cc = stemp;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult GetProduct(Int64 catid = 0)
        {
            if(catid == 0) 
                return View(this.cc.Products.ToList());
            else
            {
                var v = from t in cc.Products
                        where t.CategoryID == catid
                        select t;
                return View(v.ToList());
            }
        }

        public IActionResult About()
        {
            return View();
        }

    }
}

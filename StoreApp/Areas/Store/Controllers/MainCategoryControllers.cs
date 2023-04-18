using Microsoft.AspNetCore.Mvc;
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
    public class MainCategoryControllers : Controller
    {
        StoreContext cntx;
        public MainCategoryControllers(StoreContext temp)
        {
            this.cntx = temp;
        }
        public IActionResult Index()
        {
            return View(this.cntx.MainCategories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Create(MainCategory rec)
        {
            if (ModelState.IsValid)
            {
                this.cntx.MainCategories.Add(rec);
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Int64 Id)
        {
            var rec = this.cntx.MainCategories.Find(Id);

            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(MainCategory rec)
        {
            if (ModelState.IsValid)
            {
                this.cntx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }


        [HttpGet]
        public IActionResult Delete(Int64 Id)
        {
            var rec = this.cntx.MainCategories.Find(Id);
            this.cntx.MainCategories.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

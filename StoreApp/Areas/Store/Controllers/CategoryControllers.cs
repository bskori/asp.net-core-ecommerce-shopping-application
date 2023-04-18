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
    public class CategoryControllers : Controller
    {
        StoreContext cntx;
        public CategoryControllers(StoreContext temp)
        {
            this.cntx = temp;
        }
        public IActionResult Index()
        {
            return View(this.cntx.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MainCategory = new SelectList(this.cntx.MainCategories.ToList(), "MainCategoryID", "MainCategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category rec)
        {
            this.cntx.Categories.Add(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Int64 Id)
        {
            var rec = this.cntx.Categories.Find(Id);
            ViewBag.MainCategory = new SelectList(this.cntx.MainCategories.ToList(), "MainCategoryID", "MainCategoryName", rec.CategoryID);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Category rec)
        {
            this.cntx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Int64 Id)
        {
            var rec = this.cntx.Categories.Find(Id);
            this.cntx.Categories.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

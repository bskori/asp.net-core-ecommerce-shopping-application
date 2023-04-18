
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.CustFilter;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Areas.Store.Controllers
{
    [Area("Store")]
    [StoreAuth]
    public class ProductControllers : Controller
    {
        StoreContext cntx;
        IWebHostEnvironment host;
        public ProductControllers(StoreContext ctemp,IWebHostEnvironment hosttemp)
        {
            this.cntx = ctemp;
            this.host = hosttemp;
        }
        public IActionResult Index()
        {
            return View(this.cntx.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product rec)
        {
            if (ModelState.IsValid)
            {
                if(rec.Photo != null)
                {
                    if(rec.Photo.Length > 0)
                    {
                        string filepath = host.WebRootPath + @"\PhotoPath\" +
                            rec.Photo.FileName;
                        rec.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                        rec.photopath = @"\PhotoPath\" + rec.Photo.FileName;
                    }
                }
                this.cntx.Products.Add(rec);
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            
            this.cntx.Products.Add(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Int64 Id)
        {
            var rec = this.cntx.Products.Find(Id);
            ViewBag.Category = new SelectList(this.cntx.Categories.ToList(), "CategoryID", "CategoryName",rec.CategoryID);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(Product rec)
        {
            this.cntx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Int64 Id)
        {
            var rec = this.cntx.Products.Find(Id);
            this.cntx.Products.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

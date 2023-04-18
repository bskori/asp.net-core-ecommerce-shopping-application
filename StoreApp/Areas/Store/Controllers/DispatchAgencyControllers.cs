using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Models;
using StoreApp.CustFilter;

namespace StoreApp.Areas.Store.Controllers
{
    [Area("Store")]
    [StoreAuth]
    public class DispatchAgencyControllers : Controller
    {
        StoreContext cntx;
        public DispatchAgencyControllers(StoreContext stemp)
        {
            this.cntx = stemp;
        }
        public IActionResult Index()
        {
            return View(this.cntx.DispatchAgencies.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DispatchAgency rec)
        {
            if (ModelState.IsValid)
            {
                this.cntx.DispatchAgencies.Add(rec);
                this.cntx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Edit(Int64 Id)
        {
            var rec = this.cntx.DispatchAgencies.Find(Id);
            return View(rec);
        }

        [HttpPost]
        public IActionResult Edit(DispatchAgency rec)
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
            var rec = this.cntx.DispatchAgencies.Find(Id);
            this.cntx.DispatchAgencies.Remove(rec);
            this.cntx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

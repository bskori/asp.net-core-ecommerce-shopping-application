using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewComponents
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        StoreContext cc;
        public CategoryMenuViewComponent(StoreContext stemp)
        {
            this.cc = stemp;
        }

        public IViewComponentResult Invoke()
        {
            return View(this.cc.Categories.ToList());
        }

    }
}

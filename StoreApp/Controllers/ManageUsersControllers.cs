using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.CustFilter;
using StoreApp.Models;
using StoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
   
    public class ManageUsersControllers : Controller
    {
        StoreContext cntx;
      
        public ManageUsersControllers(StoreContext temp)
        {
            this.cntx = temp;
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationVM rec)
        {
            if (ModelState.IsValid)
            {
                User urec = new User();
                urec.FirstName = rec.FirstName;
                urec.LastName = rec.LastName;
                urec.EmailID = rec.EmailID;
                urec.MobNo = rec.MobileNo;
                urec.Password = rec.Password;
                this.cntx.Users.Add(urec);
                this.cntx.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM rec)
        {
            if (ModelState.IsValid)
            {
                User urec = this.cntx.Users.SingleOrDefault(p => p.EmailID == rec.EmailID && p.Password == rec.Password);
                if(urec != null)
                {
                    HttpContext.Session.SetString("UserID", urec.UserID.ToString());
                    HttpContext.Session.SetString("UserName", urec.FirstName.ToString());
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid EmailID or Password!");
                return View(rec);
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

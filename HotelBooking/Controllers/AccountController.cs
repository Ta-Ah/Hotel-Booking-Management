using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;
using System.Web.Security;

namespace HotelBooking.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Mambership model)
        {
            using (var context = new OfficeEntities())
            {
                bool isvalid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if(isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "ManagerTable");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Users model)
        {
            using(var context = new OfficeEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        OceanParadiseeHotelEntities db = new OceanParadiseeHotelEntities();


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application gallery page.";

            return View();
        }
        public ActionResult RoomType()
        {

            ViewBag.Message = "Your application roomtype page.";
            List<room_tab> list = db.room_tab.ToList();
           // var connections = new List<room_tab>();

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Your LogIn page.";

            return View();
        }
        [HttpPost]
        public ActionResult LogIn(GUEST_TABLE user)
        { 
            if (ModelState.IsValid == true)
            {
                var credential = db.GUEST_TABLE.Where(model => model.Guest_Email == user.Guest_Email && model.Guest_PassWword == user.Guest_PassWword).FirstOrDefault();
                Console.WriteLine(credential);
                if (credential == null)
                {
                    ViewBag.ErrorMessage = "Login Faild";
                    return View();
                }
                else
                {
                    
                    return RedirectToAction("Index", "Home");
                    // return RedirectToAction("Registration", "UserRegistration");
                }

            }
            return View();
        }
       


        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "Guest_Id, Guest_Name, Guest_Email,Guest_PassWword,Guest_Phone")] GUEST_TABLE user)
        {
            if (ModelState.IsValid)
            {

                    db.GUEST_TABLE.Add(user);
                    db.SaveChanges();
                    return View();

            }
            return View();

        }
        public ActionResult AdminLogIn()
        {
            ViewBag.Message = "Your Admin page.";

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn(AdminPanel user)
        {
            if (ModelState.IsValid == true)
            {
                var credential = db.AdminPanels.Where(model => model.email == user.email && model.loginPassword == user.loginPassword).FirstOrDefault();
                Console.WriteLine(credential);
                if (credential == null)
                {
                    ViewBag.ErrorMessage = "Login Faild";
                    return View();
                }
                else
                {

                    return RedirectToAction("Index", "Admin");
                    // return RedirectToAction("Registration", "UserRegistration");
                }

            }
            return View();
        }

    }
}
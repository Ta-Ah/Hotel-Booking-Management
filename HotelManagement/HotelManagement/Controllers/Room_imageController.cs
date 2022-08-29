using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class Room_imageController : Controller
    {
        private OceanParadiseeHotelEntities db = new OceanParadiseeHotelEntities();

        // GET: Room_image
        public ActionResult Index()
        {
            var room_image = db.Room_image.Include(r => r.AdminPanel);
            return View(room_image.ToList());
        }

        // GET: Room_image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_image room_image = db.Room_image.Find(id);
            if (room_image == null)
            {
                return HttpNotFound();
            }
            return View(room_image);
        }

        // GET: Room_image/Create
        public ActionResult Create()
        {
            ViewBag.adminID = new SelectList(db.AdminPanels, "adminID", "FullName");
            return View();
        }

        // POST: Room_image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "room_id,adminID,image")] Room_image room_image)
        {
            if (ModelState.IsValid)
            {
                db.Room_image.Add(room_image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adminID = new SelectList(db.AdminPanels, "adminID", "FullName", room_image.adminID);
            return View(room_image);
        }

        // GET: Room_image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_image room_image = db.Room_image.Find(id);
            if (room_image == null)
            {
                return HttpNotFound();
            }
            ViewBag.adminID = new SelectList(db.AdminPanels, "adminID", "FullName", room_image.adminID);
            return View(room_image);
        }

        // POST: Room_image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "room_id,adminID,image")] Room_image room_image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adminID = new SelectList(db.AdminPanels, "adminID", "FullName", room_image.adminID);
            return View(room_image);
        }

        // GET: Room_image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_image room_image = db.Room_image.Find(id);
            if (room_image == null)
            {
                return HttpNotFound();
            }
            return View(room_image);
        }

        // POST: Room_image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room_image room_image = db.Room_image.Find(id);
            db.Room_image.Remove(room_image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

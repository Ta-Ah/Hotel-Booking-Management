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
    public class BookingsController : Controller
    {
        private OceanParadiseeHotelEntities db = new OceanParadiseeHotelEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.GUEST_TABLE).Include(b => b.room_tab);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Guest_id = new SelectList(db.GUEST_TABLE, "Guest_Id", "Guest_Name");
            ViewBag.Room_type = new SelectList(db.room_tab, "room_type", "room_type");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_id,Guest_id,Booking_date,Check_in,Check_out,Guest_num,Room_type,Total_Room")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Guest_id = new SelectList(db.GUEST_TABLE, "Guest_Id", "Guest_Name", booking.Guest_id);
            ViewBag.Room_type = new SelectList(db.room_tab, "room_type", "room_type", booking.Room_type);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Guest_id = new SelectList(db.GUEST_TABLE, "Guest_Id", "Guest_Name", booking.Guest_id);
            ViewBag.Room_type = new SelectList(db.room_tab, "room_type", "room_type", booking.Room_type);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_id,Guest_id,Booking_date,Check_in,Check_out,Guest_num,Room_type,Total_Room")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Guest_id = new SelectList(db.GUEST_TABLE, "Guest_Id", "Guest_Name", booking.Guest_id);
            ViewBag.Room_type = new SelectList(db.room_tab, "room_type", "room_type", booking.Room_type);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

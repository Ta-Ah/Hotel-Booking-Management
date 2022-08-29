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
    public class PAYMENTsController : Controller
    {
        private OceanParadiseeHotelEntities db = new OceanParadiseeHotelEntities();

        // GET: PAYMENTs
        public ActionResult Index()
        {
            var pAYMENTs = db.PAYMENTs.Include(p => p.Booking);
            return View(pAYMENTs.ToList());
        }

        // GET: PAYMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.PAYMENTs.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Create
        public ActionResult Create()
        {
            ViewBag.Booking_id = new SelectList(db.Bookings, "Booking_id", "Booking_id");
            return View();
        }

        // POST: PAYMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PATMENT_ID,Booking_id,PAYMENT_DATE,TOTAL_AMMOUNT")] PAYMENT pAYMENT)
        {
            if (ModelState.IsValid)
            {

                
                db.PAYMENTs.Add(pAYMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Booking_id = new SelectList(db.Bookings, "Booking_id", "Booking_id", pAYMENT.Booking_id);
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.PAYMENTs.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Booking_id = new SelectList(db.Bookings, "Booking_id", "Booking_id", pAYMENT.Booking_id);
            return View(pAYMENT);
        }

        // POST: PAYMENTs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PATMENT_ID,Booking_id,PAYMENT_DATE,TOTAL_AMMOUNT")] PAYMENT pAYMENT)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(pAYMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Booking_id = new SelectList(db.Bookings, "Booking_id", "Booking_id", pAYMENT.Booking_id);
            return View(pAYMENT);
        }

        // GET: PAYMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT pAYMENT = db.PAYMENTs.Find(id);
            if (pAYMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT);
        }

        // POST: PAYMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAYMENT pAYMENT = db.PAYMENTs.Find(id);
            db.PAYMENTs.Remove(pAYMENT);
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

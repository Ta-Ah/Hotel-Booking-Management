using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelBooking;

namespace HotelBooking.Controllers
{
    [Authorize]
    public class ManagerTablesController : Controller
    {
        private OfficeEntities db = new OfficeEntities();

        // GET: ManagerTables
        public ActionResult Index()
        {
            return View(db.ManagerTable.ToList());
        }

        // GET: ManagerTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerTable managerTable = db.ManagerTable.Find(id);
            if (managerTable == null)
            {
                return HttpNotFound();
            }
            return View(managerTable);
        }

        // GET: ManagerTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManageId,ManageName,Manageddress,ManageContact")] ManagerTable managerTable)
        {
            if (ModelState.IsValid)
            {
                db.ManagerTable.Add(managerTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(managerTable);
        }

        // GET: ManagerTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerTable managerTable = db.ManagerTable.Find(id);
            if (managerTable == null)
            {
                return HttpNotFound();
            }
            return View(managerTable);
        }

        // POST: ManagerTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManageId,ManageName,Manageddress,ManageContact")] ManagerTable managerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(managerTable);
        }

        // GET: ManagerTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerTable managerTable = db.ManagerTable.Find(id);
            if (managerTable == null)
            {
                return HttpNotFound();
            }
            return View(managerTable);
        }

        // POST: ManagerTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerTable managerTable = db.ManagerTable.Find(id);
            db.ManagerTable.Remove(managerTable);
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

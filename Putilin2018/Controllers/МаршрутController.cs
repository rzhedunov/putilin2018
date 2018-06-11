using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Putilin2018.Models;

namespace Putilin2018.Controllers
{
    public class МаршрутController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Маршрут
        public ActionResult Index()
        {
            return View(db.Маршрут.ToList());
        }

        // GET: Маршрут/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Маршрут маршрут = db.Маршрут.Find(id);
            if (маршрут == null)
            {
                return HttpNotFound();
            }
            return View(маршрут);
        }

        // GET: Маршрут/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Маршрут/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_маршрута,Примечание")] Маршрут маршрут)
        {
            if (ModelState.IsValid)
            {
                db.Маршрут.Add(маршрут);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(маршрут);
        }

        // GET: Маршрут/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Маршрут маршрут = db.Маршрут.Find(id);
            if (маршрут == null)
            {
                return HttpNotFound();
            }
            return View(маршрут);
        }

        // POST: Маршрут/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_маршрута,Примечание")] Маршрут маршрут)
        {
            if (ModelState.IsValid)
            {
                db.Entry(маршрут).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(маршрут);
        }

        // GET: Маршрут/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Маршрут маршрут = db.Маршрут.Find(id);
            if (маршрут == null)
            {
                return HttpNotFound();
            }
            return View(маршрут);
        }

        // POST: Маршрут/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Маршрут маршрут = db.Маршрут.Find(id);
            db.Маршрут.Remove(маршрут);
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

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
    public class ЗадачаController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Задача
        public ActionResult Index()
        {
            var задача = db.Задача.Include(з => з.Группы_задач);
            return View(задача.ToList());
        }

        // GET: Задача/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Задача задача = db.Задача.Find(id);
            if (задача == null)
            {
                return HttpNotFound();
            }
            return View(задача);
        }

        // GET: Задача/Create
        public ActionResult Create()
        {
            ViewBag.Группа_задачID = new SelectList(db.Группы_задач, "Id", "Название_группы");
            return View();
        }

        // POST: Задача/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_задачи,Группа_задачID,Примечание")] Задача задача)
        {
            if (ModelState.IsValid)
            {
                db.Задача.Add(задача);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Группа_задачID = new SelectList(db.Группы_задач, "Id", "Название_группы", задача.Группа_задачID);
            return View(задача);
        }

        // GET: Задача/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Задача задача = db.Задача.Find(id);
            if (задача == null)
            {
                return HttpNotFound();
            }
            ViewBag.Группа_задачID = new SelectList(db.Группы_задач, "Id", "Название_группы", задача.Группа_задачID);
            return View(задача);
        }

        // POST: Задача/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_задачи,Группа_задачID,Примечание")] Задача задача)
        {
            if (ModelState.IsValid)
            {
                db.Entry(задача).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Группа_задачID = new SelectList(db.Группы_задач, "Id", "Название_группы", задача.Группа_задачID);
            return View(задача);
        }

        // GET: Задача/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Задача задача = db.Задача.Find(id);
            if (задача == null)
            {
                return HttpNotFound();
            }
            return View(задача);
        }

        // POST: Задача/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Задача задача = db.Задача.Find(id);
            db.Задача.Remove(задача);
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

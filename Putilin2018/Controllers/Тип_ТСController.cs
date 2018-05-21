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
    public class Тип_ТСController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Тип_ТС
        public ActionResult Index()
        {
            return View(db.Тип_ТС.ToList());
        }

        // GET: Тип_ТС/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип_ТС тип_ТС = db.Тип_ТС.Find(id);
            if (тип_ТС == null)
            {
                return HttpNotFound();
            }
            return View(тип_ТС);
        }

        // GET: Тип_ТС/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Тип_ТС/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_типа")] Тип_ТС тип_ТС)
        {
            if (ModelState.IsValid)
            {
                db.Тип_ТС.Add(тип_ТС);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(тип_ТС);
        }

        // GET: Тип_ТС/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип_ТС тип_ТС = db.Тип_ТС.Find(id);
            if (тип_ТС == null)
            {
                return HttpNotFound();
            }
            return View(тип_ТС);
        }

        // POST: Тип_ТС/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_типа")] Тип_ТС тип_ТС)
        {
            if (ModelState.IsValid)
            {
                db.Entry(тип_ТС).State = EntityState.Modified;
                тип_ТС.Название_типа = тип_ТС.Название_типа.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(тип_ТС);
        }

        // GET: Тип_ТС/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип_ТС тип_ТС = db.Тип_ТС.Find(id);
            if (тип_ТС == null)
            {
                return HttpNotFound();
            }
            return View(тип_ТС);
        }

        // POST: Тип_ТС/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Тип_ТС тип_ТС = db.Тип_ТС.Find(id);
            db.Тип_ТС.Remove(тип_ТС);
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

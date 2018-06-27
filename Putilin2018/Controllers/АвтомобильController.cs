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
    public class АвтомобильController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Автомобиль
        public ActionResult Index()
        {
            var автомобиль = db.Автомобиль.Include(а => а.Тип_ТС);
            return View(автомобиль.ToList());
        }

        // GET: Автомобиль/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Автомобиль автомобиль = db.Автомобиль.Find(id);
            if (автомобиль == null)
            {
                return HttpNotFound();
            }
            return View(автомобиль);
        }

        // GET: Автомобиль/Create
        public ActionResult Create()
        {
            ViewBag.Тип_ТСID = new SelectList(db.Тип_ТС, "Id", "Название_типа");
            return View();
        }

        // POST: Автомобиль/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_автомобиля,Госномер,Примечание,Тип_ТСID")] Автомобиль автомобиль)
        {
            if (ModelState.IsValid)
            {
                db.Автомобиль.Add(автомобиль);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Тип_ТСID = new SelectList(db.Тип_ТС, "Id", "Название_типа", автомобиль.Тип_ТСID);
            return View(автомобиль);
        }

        // GET: Автомобиль/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Автомобиль автомобиль = db.Автомобиль.Find(id);
            if (автомобиль == null)
            {
                return HttpNotFound();
            }
            ViewBag.Тип_ТСID = new SelectList(db.Тип_ТС, "Id", "Название_типа", автомобиль.Тип_ТСID);
            return View(автомобиль);
        }

        // POST: Автомобиль/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_автомобиля,Госномер,Примечание,Тип_ТСID")] Автомобиль автомобиль)
        {
            автомобиль.Госномер.Trim();
            автомобиль.Название_автомобиля.Trim();
            автомобиль.Примечание.Trim();

            if (ModelState.IsValid)
            {
                db.Entry(автомобиль).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Тип_ТСID = new SelectList(db.Тип_ТС, "Id", "Название_типа", автомобиль.Тип_ТСID);
            return View(автомобиль);
        }

        // GET: Автомобиль/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Автомобиль автомобиль = db.Автомобиль.Find(id);
            if (автомобиль == null)
            {
                return HttpNotFound();
            }
            return View(автомобиль);
        }

        // POST: Автомобиль/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Автомобиль автомобиль = db.Автомобиль.Find(id);
            db.Автомобиль.Remove(автомобиль);
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

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
    public class Пункт_доставкиController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Пункт_доставки
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Пункт_доставки.ToList());
        }

        // GET: Пункт_доставки/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункт_доставки пункт_доставки = db.Пункт_доставки.Find(id);
            if (пункт_доставки == null)
            {
                return HttpNotFound();
            }
            return View(пункт_доставки);
        }

        // GET: Пункт_доставки/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Пункт_доставки/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_пункта,Адрес,Регулярность")] Пункт_доставки пункт_доставки)
        {
            if (ModelState.IsValid)
            {
                db.Пункт_доставки.Add(пункт_доставки);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(пункт_доставки);
        }

        // GET: Пункт_доставки/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункт_доставки пункт_доставки = db.Пункт_доставки.Find(id);
            if (пункт_доставки == null)
            {
                return HttpNotFound();
            }
            return View(пункт_доставки);
        }

        // POST: Пункт_доставки/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_пункта,Адрес,Регулярность")] Пункт_доставки пункт_доставки)
        {
            if (ModelState.IsValid)
            {
                db.Entry(пункт_доставки).State = EntityState.Modified;
                пункт_доставки.Название_пункта= пункт_доставки.Название_пункта.Trim();
                пункт_доставки.Адрес= пункт_доставки.Адрес.Trim();
                пункт_доставки.Регулярность= пункт_доставки.Регулярность.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(пункт_доставки);
        }

        // GET: Пункт_доставки/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункт_доставки пункт_доставки = db.Пункт_доставки.Find(id);
            if (пункт_доставки == null)
            {
                return HttpNotFound();
            }
            return View(пункт_доставки);
        }

        // POST: Пункт_доставки/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Пункт_доставки пункт_доставки = db.Пункт_доставки.Find(id);
            db.Пункт_доставки.Remove(пункт_доставки);
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

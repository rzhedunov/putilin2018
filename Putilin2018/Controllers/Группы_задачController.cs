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
    public class Группы_задачController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Группы_задач
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Группы_задач.ToList());
        }

        // GET: Группы_задач/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Группы_задач группы_задач = db.Группы_задач.Find(id);
            if (группы_задач == null)
            {
                return HttpNotFound();
            }
            return View(группы_задач);
        }

        // GET: Группы_задач/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Группы_задач/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Название_группы,Примечание")] Группы_задач группы_задач)
        {
            if (ModelState.IsValid)
            {
                db.Группы_задач.Add(группы_задач);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(группы_задач);
        }

        // GET: Группы_задач/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Группы_задач группы_задач = db.Группы_задач.Find(id);
            if (группы_задач == null)
            {
                return HttpNotFound();
            }
            return View(группы_задач);
        }

        // POST: Группы_задач/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Название_группы,Примечание")] Группы_задач группы_задач)
        {
            if (ModelState.IsValid)
            {
                db.Entry(группы_задач).State = EntityState.Modified;
                группы_задач.Название_группы = группы_задач.Название_группы.Trim();
                группы_задач.Примечание= группы_задач.Примечание.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(группы_задач);
        }

        // GET: Группы_задач/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Группы_задач группы_задач = db.Группы_задач.Find(id);
            if (группы_задач == null)
            {
                return HttpNotFound();
            }
            return View(группы_задач);
        }

        // POST: Группы_задач/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Группы_задач группы_задач = db.Группы_задач.Find(id);
            db.Группы_задач.Remove(группы_задач);
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

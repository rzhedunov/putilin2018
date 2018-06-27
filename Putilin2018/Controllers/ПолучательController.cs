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
    public class ПолучательController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Получатель
        //[Authorize]
        public ActionResult Index()
        {
            var получатель = db.Получатель.Include(п => п.Пункт_доставки);
            return View(получатель.ToList());
        }

        // GET: Получатель/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Получатель получатель = db.Получатель.Find(id);
            if (получатель == null)
            {
                return HttpNotFound();
            }
            return View(получатель);
        }

        // GET: Получатель/Create
        public ActionResult Create()
        {
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта");
            return View();
        }

        // POST: Получатель/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ФИО,E_mail,Телефон,Пункт_доставкиID")] Получатель получатель)
        {
            if (ModelState.IsValid)
            {
                db.Получатель.Add(получатель);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", получатель.Пункт_доставкиID);
            return View(получатель);
        }

        // GET: Получатель/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Получатель получатель = db.Получатель.Find(id);
            if (получатель == null)
            {
                return HttpNotFound();
            }
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", получатель.Пункт_доставкиID);
            return View(получатель);
        }

        // POST: Получатель/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ФИО,E_mail,Телефон,Пункт_доставкиID")] Получатель получатель)
        {
            получатель.Телефон = получатель.Телефон.Trim();
            получатель.ФИО = получатель.ФИО.Trim();
            if (ModelState.IsValid)
            {
                db.Entry(получатель).State = EntityState.Modified;
                получатель.ФИО = получатель.ФИО.Trim();
                получатель.E_mail= получатель.E_mail.Trim();
                получатель.Телефон= получатель.Телефон.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", получатель.Пункт_доставкиID);
            return View(получатель);
        }

        // GET: Получатель/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Получатель получатель = db.Получатель.Find(id);
            if (получатель == null)
            {
                return HttpNotFound();
            }
            return View(получатель);
        }

        // POST: Получатель/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Получатель получатель = db.Получатель.Find(id);
            db.Получатель.Remove(получатель);
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

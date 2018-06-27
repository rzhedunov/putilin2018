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
    public class РемонтController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Ремонт
        public ActionResult Index()
        {
            var ремонт = db.Ремонт.Include(р => р.Автомобиль).Include(р => р.Статус_заявки);
            ремонт = ремонт.OrderByDescending(s => s.Дата_заявки);
            return View(ремонт.ToList());
        }

        // GET: Ремонт/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = db.Ремонт.Find(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            return View(ремонт);
        }

        // GET: Ремонт/Create
        public ActionResult Create()
        {
            ViewBag.RepairDate = "" + DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "-" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day;
            ViewBag.RepairDate2 = "" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day + "." + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "." + DateTime.Now.Year;

            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля");
            ViewBag.Статус_заявкиID = new SelectList(db.Статус_заявки, "Id", "Статус");
            return View();
        }

        // POST: Ремонт/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Дата_заявки,АвтомобильID,Содержание,Дата_выполнения,Статус_заявкиID,Стоимость_ремонта,Примечание")] Ремонт ремонт)
        {
            ремонт.Содержание = ремонт.Содержание.Trim();
            ремонт.Примечание = ремонт.Примечание.Trim();
            if (ModelState.IsValid)
            {
                db.Ремонт.Add(ремонт);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", ремонт.АвтомобильID);
            ViewBag.Статус_заявкиID = new SelectList(db.Статус_заявки, "Id", "Статус", ремонт.Статус_заявкиID);
            return View(ремонт);
        }

        // GET: Ремонт/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = db.Ремонт.Find(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairDate = "" + ремонт.Дата_заявки.Year + "-" + (ремонт.Дата_заявки.Month < 10 ? "0" : "") + ремонт.Дата_заявки.Month + "-" + (ремонт.Дата_заявки.Day < 10 ? "0" : "") + ремонт.Дата_заявки.Day;
            ViewBag.RepairDate2 = "" + (ремонт.Дата_заявки.Day < 10 ? "0" : "") + ремонт.Дата_заявки.Day + "." + (ремонт.Дата_заявки.Month < 10 ? "0" : "") + ремонт.Дата_заявки.Month + "." + ремонт.Дата_заявки.Year;
            ViewBag.RepairDateEx = "" + ремонт.Дата_выполнения.Year + "-" + (ремонт.Дата_выполнения.Month < 10 ? "0" : "") + ремонт.Дата_выполнения.Month + "-" + (ремонт.Дата_выполнения.Day < 10 ? "0" : "") + ремонт.Дата_выполнения.Day;
            ViewBag.RepairDateEx2 = "" + (ремонт.Дата_выполнения.Day < 10 ? "0" : "") + ремонт.Дата_выполнения.Day + "." + (ремонт.Дата_выполнения.Month < 10 ? "0" : "") + ремонт.Дата_выполнения.Month + "." + ремонт.Дата_выполнения.Year;

            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", ремонт.АвтомобильID);
            ViewBag.Статус_заявкиID = new SelectList(db.Статус_заявки, "Id", "Статус", ремонт.Статус_заявкиID);
            return View(ремонт);
        }

        // POST: Ремонт/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Дата_заявки,АвтомобильID,Содержание,Дата_выполнения,Статус_заявкиID,Стоимость_ремонта,Примечание")] Ремонт ремонт)
        {
            ремонт.Содержание = ремонт.Содержание.Trim();
            ремонт.Примечание = ремонт.Примечание.Trim();
            if (ModelState.IsValid)
            {
                db.Entry(ремонт).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", ремонт.АвтомобильID);
            ViewBag.Статус_заявкиID = new SelectList(db.Статус_заявки, "Id", "Статус", ремонт.Статус_заявкиID);
            return View(ремонт);
        }

        // GET: Ремонт/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = db.Ремонт.Find(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            return View(ремонт);
        }

        // POST: Ремонт/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ремонт ремонт = db.Ремонт.Find(id);
            db.Ремонт.Remove(ремонт);
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

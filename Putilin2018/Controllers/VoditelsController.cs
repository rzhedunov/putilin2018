﻿using System;
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
    public class VoditelsController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Voditels
        [Authorize(Users = "admin@mail.ru")]
        public ActionResult Index()
        {
            return View(db.Voditel.ToList());
        }

        // GET: Voditels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voditel voditel = db.Voditel.Find(id);
            if (voditel == null)
            {
                return HttpNotFound();
            }
            return View(voditel);
        }

        // GET: Voditels/Create
        public ActionResult Create()
        {
            ViewBag.RaceDate = "" + DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "-" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day;
            ViewBag.RaceDate2 = "" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day + "." + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "." + DateTime.Now.Year;

            return View();
        }

        // POST: Voditels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fio,license_expire,categories")] Voditel voditel)
        {
            if (ModelState.IsValid)
            {
                db.Voditel.Add(voditel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voditel);
        }

        // GET: Voditels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voditel voditel = db.Voditel.Find(id);
            if (voditel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaceDate = "" + voditel.license_expire.Year + "-" + (voditel.license_expire.Month < 10 ? "0" : "") + voditel.license_expire.Month + "-" + (voditel.license_expire.Day < 10 ? "0" : "") + voditel.license_expire.Day;
            ViewBag.RaceDate2 = "" + (voditel.license_expire.Day < 10 ? "0" : "") + voditel.license_expire.Day + "." + (voditel.license_expire.Month < 10 ? "0" : "") + voditel.license_expire.Month + "." + voditel.license_expire.Year;

            return View(voditel);
        }

        // POST: Voditels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fio,license_expire,categories")] Voditel voditel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voditel).State = EntityState.Modified;
                voditel.fio = voditel.fio.Trim();
                voditel.categories = voditel.categories.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voditel);
        }

        // GET: Voditels/Delete/5
        public ActionResult Delete(int? id)
        {

            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voditel voditel = db.Voditel.Find(id);
            if (voditel == null)
            {
                return HttpNotFound();
            }

            ViewBag.AllowDelete = 1;
            var РейсыВодителя = db.Рейс.Where(x =>(x.ВодительID == (int)id));
            if (РейсыВодителя.Count() > 0) { ViewBag.AllowDelete = 0; }

            return View(voditel);
        }

        // POST: Voditels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voditel voditel = db.Voditel.Find(id);
            db.Voditel.Remove(voditel);
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

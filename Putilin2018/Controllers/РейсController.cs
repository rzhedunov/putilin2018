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
    public class РейсController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Рейс
        public ActionResult Index()
        {
            var рейс = db.Рейс.Include(р => р.Voditel).Include(р => р.Автомобиль).Include(р => р.Задача);
            рейс = рейс.OrderByDescending(s => s.Номер_путевого_листа);
            return View(рейс.ToList());
        }

        // GET: Рейс/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Рейс рейс = db.Рейс.Find(id);
            if (рейс == null)
            {
                return HttpNotFound();
            }
            return View(рейс);
        }

        // GET: Рейс/Create
        public ActionResult Create()
        {
            ViewBag.RaceDate = "" + DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "-" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day;
            ViewBag.RaceDate2 = "" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day + "." + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month + "." + DateTime.Now.Year;
            
            var maxlist = db.get_last_racenumber();
            var autos = db.get_last_fuel_and_distance();
            ViewBag.autos = autos;

            int numPL = (int)maxlist.First() + 1;
            
            if (numPL<10) ViewBag.NewListNumber = "ПЛ0000" + numPL.ToString();
            else if (numPL<100) ViewBag.NewListNumber = "ПЛ000" + numPL.ToString();
            else if (numPL<1000) ViewBag.NewListNumber = "ПЛ00" + numPL.ToString();
            else if (numPL<10000) ViewBag.NewListNumber = "ПЛ0" + numPL.ToString();



            ViewBag.ВодительID = new SelectList(db.Voditel, "Id", "fio");
            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля");
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи");
            return View();
        }

        // POST: Рейс/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Номер_путевого_листа,Дата_рейса,Остаток_ГСМ_на_въезде,Выдано_ГСМ,Нач_спидометр,Норма,Пробег,Расход_ГСМ,ВодительID,ЗадачаID,АвтомобильID,Примечание")] Рейс рейс)
        {
            if (ModelState.IsValid)
            {
                db.Рейс.Add(рейс);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ВодительID = new SelectList(db.Voditel, "Id", "fio", рейс.ВодительID);
            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", рейс.АвтомобильID);
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", рейс.ЗадачаID);
            return View(рейс);
        }

        // GET: Рейс/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Рейс рейс = db.Рейс.Find(id);
            if (рейс == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaceDate = "" + рейс.Дата_рейса.Year + "-" + (рейс.Дата_рейса.Month<10 ? "0" : "") + рейс.Дата_рейса.Month + "-" + (рейс.Дата_рейса.Day < 10 ? "0" : "") + рейс.Дата_рейса.Day;
            ViewBag.RaceDate2 = "" + (рейс.Дата_рейса.Day < 10 ? "0" : "") + рейс.Дата_рейса.Day + "." + (рейс.Дата_рейса.Month<10 ? "0" : "") + рейс.Дата_рейса.Month + "."  + рейс.Дата_рейса.Year;
            ViewBag.ВодительID = new SelectList(db.Voditel, "Id", "fio", рейс.ВодительID);
            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", рейс.АвтомобильID);
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", рейс.ЗадачаID);
            return View(рейс);
        }

        // POST: Рейс/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Номер_путевого_листа,Дата_рейса,Остаток_ГСМ_на_въезде,Выдано_ГСМ,Нач_спидометр,Норма,Пробег,Расход_ГСМ,ВодительID,ЗадачаID,АвтомобильID,Примечание")] Рейс рейс)
        {
            рейс.Номер_путевого_листа = рейс.Номер_путевого_листа.Trim();
            рейс.Примечание = рейс.Примечание.Trim();

            if (ModelState.IsValid)
            {
                db.Entry(рейс).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ВодительID = new SelectList(db.Voditel, "Id", "fio", рейс.ВодительID);
            ViewBag.АвтомобильID = new SelectList(db.Автомобиль, "Id", "Название_автомобиля", рейс.АвтомобильID);
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", рейс.ЗадачаID);
            return View(рейс);
        }

        // GET: Рейс/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Рейс рейс = db.Рейс.Find(id);
            if (рейс == null)
            {
                return HttpNotFound();
            }
            return View(рейс);
        }

        // POST: Рейс/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Рейс рейс = db.Рейс.Find(id);
            db.Рейс.Remove(рейс);
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

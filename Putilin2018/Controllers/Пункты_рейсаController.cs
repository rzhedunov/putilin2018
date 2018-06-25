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
    public class Пункты_рейсаController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Пункты_рейса
        public ActionResult Index(int? РейсID)
        {
            var пункты_рейса = db.Пункты_рейса.Include(п => п.Задача).Include(п => п.Получатель).Include(п => п.Пункт_доставки).Include(п => п.Рейс);
            if (РейсID != null && РейсID != 0)
            {
                пункты_рейса = пункты_рейса.Where(p => p.РейсID == РейсID);
                ViewBag.РейсID = РейсID;
            }
            else
            {
                пункты_рейса = пункты_рейса.Where(p => p.РейсID == -1);
            }

            if (пункты_рейса.Count() > 0)
            {
                ViewBag.Message2 = "Всего пунктов в рейсе: " + пункты_рейса.Count().ToString();
            }
            else
            {
                ViewBag.Message2 = "Нет пунктов рейса! ";
            }


            return View(пункты_рейса.ToList());
        }

        // GET: Пункты_рейса/Details/5
        public ActionResult Details(int? id, int? РейсID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункты_рейса пункты_рейса = db.Пункты_рейса.Find(id);
            if (пункты_рейса == null)
            {
                return HttpNotFound();
            }
            ViewBag.РейсID = РейсID;
            return View(пункты_рейса);
        }

        // GET: Пункты_рейса/Create
        public ActionResult Create(int? РейсID)
        {
            ViewBag.РейсID = РейсID;
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи");
            ViewBag.ПолучательID = new SelectList(db.Получатель, "Id", "ФИО");
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта");
            //ViewBag.РейсID = new SelectList(db.Рейс, "Id", "Номер_путевого_листа");
            return View();
        }

        // POST: Пункты_рейса/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,РейсID,Пункт_доставкиID,ПолучательID,ЗадачаID,Время_плановое,УсловныйКод,Время_фактическое,Примечание")] Пункты_рейса пункты_рейса, int? РейсID)
        {
            ViewBag.РейсID = РейсID;
            if (ModelState.IsValid)
            {
                db.Пункты_рейса.Add(пункты_рейса);
                db.SaveChanges();

                var sender = new SenderOfConfirmationCode();
                if (sender.hasEMail(пункты_рейса.ПолучательID))
                {
                    sender.sendEMail(пункты_рейса.ПолучательID, пункты_рейса.Id, пункты_рейса.УсловныйКод);
                }

                return RedirectToAction("Index", new { РейсID = @ViewBag.РейсID });
            }

            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_рейса.ЗадачаID);
            ViewBag.ПолучательID = new SelectList(db.Получатель, "Id", "ФИО", пункты_рейса.ПолучательID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_рейса.Пункт_доставкиID);
            //ViewBag.РейсID = new SelectList(db.Рейс, "Id", "Номер_путевого_листа", пункты_рейса.РейсID);
            return View(пункты_рейса);
        }

        // GET: Пункты_рейса/Edit/5
        public ActionResult Edit(int? id, int? РейсID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункты_рейса пункты_рейса = db.Пункты_рейса.Find(id);
            if (пункты_рейса == null)
            {
                return HttpNotFound();
            }
            ViewBag.РейсID = РейсID;
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_рейса.ЗадачаID);
            ViewBag.ПолучательID = new SelectList(db.Получатель, "Id", "ФИО", пункты_рейса.ПолучательID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_рейса.Пункт_доставкиID);
            //ViewBag.РейсID = new SelectList(db.Рейс, "Id", "Номер_путевого_листа", пункты_рейса.РейсID);
            return View(пункты_рейса);
        }

        // POST: Пункты_рейса/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,РейсID,Пункт_доставкиID,ПолучательID,ЗадачаID,Время_плановое,УсловныйКод,Время_фактическое,Примечание")] Пункты_рейса пункты_рейса, int? РейсID)
        {
            ViewBag.РейсID = РейсID;
            if (ModelState.IsValid)
            {
                db.Entry(пункты_рейса).State = EntityState.Modified;
                db.SaveChanges();

                var sender = new SenderOfConfirmationCode();
                if (sender.hasEMail(пункты_рейса.ПолучательID))
                {
                    sender.sendEMail(пункты_рейса.ПолучательID, пункты_рейса.Id, пункты_рейса.УсловныйКод);
                }


                return RedirectToAction("Index", new { РейсID = @ViewBag.РейсID });
            }
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_рейса.ЗадачаID);
            ViewBag.ПолучательID = new SelectList(db.Получатель, "Id", "ФИО", пункты_рейса.ПолучательID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_рейса.Пункт_доставкиID);
            //ViewBag.РейсID = new SelectList(db.Рейс, "Id", "Номер_путевого_листа", пункты_рейса.РейсID);
            return View(пункты_рейса);
        }

        // GET: Пункты_рейса/Delete/5
        public ActionResult Delete(int? id, int? РейсID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.РейсID = РейсID;
            Пункты_рейса пункты_рейса = db.Пункты_рейса.Find(id);
            if (пункты_рейса == null)
            {
                return HttpNotFound();
            }
            return View(пункты_рейса);
        }

        // POST: Пункты_рейса/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? РейсID)
        {
            ViewBag.РейсID = РейсID;
            Пункты_рейса пункты_рейса = db.Пункты_рейса.Find(id);
            db.Пункты_рейса.Remove(пункты_рейса);
            db.SaveChanges();
            return RedirectToAction("Index", new { РейсID = @ViewBag.РейсID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Пункты_рейса/SendMark
        public ActionResult SendMark()
        {
            return View();
        }

        // GET: Пункты_рейса/ApplyMark
        public ActionResult ApplyMark(FormCollection collection)
        {
            int id = Convert.ToInt32(collection.Get("markid"));
            int code = Convert.ToInt32(collection.Get("markcode"));

            var res = db.Database.ExecuteSqlCommand("execute update_arrival_time "+id.ToString() + ", "+ code.ToString());


            return View();
        }

    }
}

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
    public class Пункты_регулярного_маршрутаController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Пункты_регулярного_маршрута
        public ActionResult Index(int? МаршрутID)
        {
            IQueryable<Пункты_регулярного_маршрута> пункты_регулярного_маршрута = db.Пункты_регулярного_маршрута.Include(п => п.Задача).Include(п => п.Маршрут).Include(п => п.Пункт_доставки);
            if (МаршрутID != null && МаршрутID != 0)
            {
                пункты_регулярного_маршрута = пункты_регулярного_маршрута.Where(p => p.МаршрутID == МаршрутID);
                ViewBag.МаршрутID = МаршрутID;                
            }
            else
            {
                пункты_регулярного_маршрута = пункты_регулярного_маршрута.Where(p => p.МаршрутID == -1);
            }
            
            if (пункты_регулярного_маршрута.Count()>0)
            { 
                ViewBag.Message2 = "Всего пунктов в маршруте: " + пункты_регулярного_маршрута.Count().ToString();
            }
            else
            {
                ViewBag.Message2 = "Нет пунктов назначения! ";
            }
            return View(пункты_регулярного_маршрута);
        }

        // GET: Пункты_регулярного_маршрута/Details/5
        public ActionResult Details(int? id, int? МаршрутID)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункты_регулярного_маршрута пункты_регулярного_маршрута = db.Пункты_регулярного_маршрута.Find(id);
            if (пункты_регулярного_маршрута == null)
            {
                return HttpNotFound();
            }
            ViewBag.МаршрутID = МаршрутID;
            return View(пункты_регулярного_маршрута);
        }

        // GET: Пункты_регулярного_маршрута/Create
        public ActionResult Create(int? МаршрутID)
        {
            ViewBag.МаршрутID = МаршрутID;
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи");
            //ViewBag.МаршрутID = new SelectList(db.Маршрут, "Id", "Название_маршрута");
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта");            
            return View();
        }

        // POST: Пункты_регулярного_маршрута/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,МаршрутID,Пункт_доставкиID,ЗадачаID,Время_плановое,Примечание")] Пункты_регулярного_маршрута пункты_регулярного_маршрута, int? МаршрутID)
        {
            ViewBag.МаршрутID = МаршрутID;
            if (ModelState.IsValid)
            {
                db.Пункты_регулярного_маршрута.Add(пункты_регулярного_маршрута);
                db.SaveChanges();
                return RedirectToAction("Index", new { МаршрутID = @ViewBag.МаршрутID });
            }
            
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_регулярного_маршрута.ЗадачаID);
            //ViewBag.МаршрутID = new SelectList(db.Маршрут, "Id", "Название_маршрута", пункты_регулярного_маршрута.МаршрутID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_регулярного_маршрута.Пункт_доставкиID);
            return View(пункты_регулярного_маршрута);
        }

        // GET: Пункты_регулярного_маршрута/Edit/5
        public ActionResult Edit(int? id, int? МаршрутID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Пункты_регулярного_маршрута пункты_регулярного_маршрута = db.Пункты_регулярного_маршрута.Find(id);
            if (пункты_регулярного_маршрута == null)
            {
                return HttpNotFound();
            }
            ViewBag.МаршрутID = МаршрутID;
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_регулярного_маршрута.ЗадачаID);
            //ViewBag.МаршрутID = new SelectList(db.Маршрут, "Id", "Название_маршрута", пункты_регулярного_маршрута.МаршрутID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_регулярного_маршрута.Пункт_доставкиID);
            return View(пункты_регулярного_маршрута);
        }

        // POST: Пункты_регулярного_маршрута/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,МаршрутID,Пункт_доставкиID,ЗадачаID,Время_плановое,Примечание")] Пункты_регулярного_маршрута пункты_регулярного_маршрута, int? МаршрутID)
        {
            ViewBag.МаршрутID = МаршрутID;
            if (ModelState.IsValid)
            {
                db.Entry(пункты_регулярного_маршрута).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { МаршрутID = @ViewBag.МаршрутID });
            }            
            ViewBag.ЗадачаID = new SelectList(db.Задача, "Id", "Название_задачи", пункты_регулярного_маршрута.ЗадачаID);
            //ViewBag.МаршрутID = new SelectList(db.Маршрут, "Id", "Название_маршрута", пункты_регулярного_маршрута.МаршрутID);
            ViewBag.Пункт_доставкиID = new SelectList(db.Пункт_доставки, "Id", "Название_пункта", пункты_регулярного_маршрута.Пункт_доставкиID);
            return View(пункты_регулярного_маршрута);
        }

        // GET: Пункты_регулярного_маршрута/Delete/5
        public ActionResult Delete(int? id, int? МаршрутID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.МаршрутID = МаршрутID;
            Пункты_регулярного_маршрута пункты_регулярного_маршрута = db.Пункты_регулярного_маршрута.Find(id);
            if (пункты_регулярного_маршрута == null)
            {
                return HttpNotFound();
            }            
            return View(пункты_регулярного_маршрута);
        }

        // POST: Пункты_регулярного_маршрута/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? МаршрутID)
        {
            ViewBag.МаршрутID = МаршрутID;
            Пункты_регулярного_маршрута пункты_регулярного_маршрута = db.Пункты_регулярного_маршрута.Find(id);
            db.Пункты_регулярного_маршрута.Remove(пункты_регулярного_маршрута);
            db.SaveChanges();
            return RedirectToAction("Index", new { МаршрутID = @ViewBag.МаршрутID });
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

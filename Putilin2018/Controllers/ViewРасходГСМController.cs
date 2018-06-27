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
    public class ViewРасходГСМController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        [HttpPost]
        // GET: ViewРасходГСМ
        public ActionResult Index(FormCollection collection)
        {            
            DateTime date_start = (collection["date_start"]==null) ? DateTime.Now : Convert.ToDateTime(collection["date_start"]);
            DateTime date_end = (collection["date_end"] == null) ? DateTime.Now : Convert.ToDateTime(collection["date_end"]);

            ViewBag.date_start = "" + (date_start.Day < 10 ? "0" : "") + date_start.Day + "." + (date_start.Month < 10 ? "0" : "") + date_start.Month + "." + date_start.Year;
            ViewBag.date_end = "" + (date_end.Day < 10 ? "0" : "") + date_end.Day + "." + (date_end.Month < 10 ? "0" : "") + date_end.Month + "." + date_end.Year;


            var reportdata = db.ViewРасходГСМ.Where(x => x.Дата_рейса> date_start && x.Дата_рейса < date_end);

            reportdata = reportdata.OrderBy(x => x.Дата_рейса);

            float sum = 0;
            foreach (ViewРасходГСМ x in reportdata) sum += x.Расход_ГСМ;
            ViewBag.sum = sum;

            return View(reportdata.ToList());
        }

        public ActionResult ChoosePeriod()
        {
            DateTime date_start = DateTime.Now.AddMonths(-1) ;
            DateTime date_end = DateTime.Now;

            ViewBag.date_start = "" + date_start.Year + "-" + (date_start.Month < 10 ? "0" : "") + date_start.Month + "-" + (date_start.Day < 10 ? "0" : "") + date_start.Day;
            ViewBag.date_end = "" + date_end.Year + "-" + (date_end.Month < 10 ? "0" : "") + date_end.Month + "-" + (date_end.Day < 10 ? "0" : "") + date_end.Day;


            return View();

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

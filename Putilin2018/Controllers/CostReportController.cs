using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Putilin2018.Models;

namespace Putilin2018.Controllers
{
    public class CostReportController : Controller
    {

        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: CostReport
        public ActionResult Index(FormCollection collection)
        {
            DateTime date_start = (collection["date_start"] == null) ? DateTime.Now : Convert.ToDateTime(collection["date_start"]);
            DateTime date_end = (collection["date_end"] == null) ? DateTime.Now : Convert.ToDateTime(collection["date_end"]);

            ViewBag.date_start = "" + (date_start.Day < 10 ? "0" : "") + date_start.Day + "." + (date_start.Month < 10 ? "0" : "") + date_start.Month + "." + date_start.Year;
            ViewBag.date_end = "" + (date_end.Day < 10 ? "0" : "") + date_end.Day + "." + (date_end.Month < 10 ? "0" : "") + date_end.Month + "." + date_end.Year;

            var reportdata = db.get_cost_report(date_start, date_end);

            //var reportdata = db.ViewРасходГСМ.Where(x => x.Дата_рейса > date_start && x.Дата_рейса < date_end);

            //reportdata = reportdata.OrderBy(x => x.Дата_рейса);

            double sum3 = 0;
            double sum4 = 0;
            double sum5 = 0;
            foreach (Putilin2018.Models.get_cost_report_Result x in reportdata)
            {
                sum3 += (double)x.fuel_paid;
                sum4 += (double)x.repair_paid;
                sum5 += (double)x.total_paid;
            }
            ViewBag.sum3 = sum3;
            ViewBag.sum4 = sum4;
            ViewBag.sum5 = sum5;
            reportdata.OrderBy(x =>x.groupname);

            return View(reportdata.ToList().OrderBy(x => x.groupname));
        }

        public ActionResult ChoosePeriod()
        {
            DateTime date_start = DateTime.Now.AddMonths(-1);
            DateTime date_end = DateTime.Now;

            ViewBag.date_start = "" + date_start.Year + "-" + (date_start.Month < 10 ? "0" : "") + date_start.Month + "-" + (date_start.Day < 10 ? "0" : "") + date_start.Day;
            ViewBag.date_end = "" + date_end.Year + "-" + (date_end.Month < 10 ? "0" : "") + date_end.Month + "-" + (date_end.Day < 10 ? "0" : "") + date_end.Day;


            return View();

        }
    }
}
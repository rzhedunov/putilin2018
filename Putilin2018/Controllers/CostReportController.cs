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
        public ActionResult Index()
        {
            DateTime date_start = DateTime.Now.AddDays(-100);
            DateTime date_end = DateTime.Now.AddDays(100);
            var report = db.get_cost_report(date_start, date_end);
            return View(report.ToList());
        }
    }
}
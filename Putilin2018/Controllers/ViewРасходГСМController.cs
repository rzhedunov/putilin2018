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

        // GET: ViewРасходГСМ
        public ActionResult Index()
        {
            return View(db.ViewРасходГСМ.ToList());
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

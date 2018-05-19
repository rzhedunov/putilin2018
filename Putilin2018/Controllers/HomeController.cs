using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Putilin2018.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания моего приложения";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Мои контакты";

            return View();
        }
    }
}
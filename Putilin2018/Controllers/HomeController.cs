using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Putilin2018.Models;


namespace Putilin2018.Controllers
{
    public class HomeController : Controller
    {
        DBRepository db = new DBRepository(new MyDatabaseEntities());

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users = "admin@mail.ru, boss@mail.ru")]
        public ActionResult Menu()
        {
            ViewBag.Message = "Меню приложения";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "О программе";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";
            return View();
        }

        [Authorize(Users = "admin@mail.ru, boss@mail.ru")]
        public ActionResult Reports()
        {
            ViewBag.Message = "Отчеты";
            return View();
        }


    }
}
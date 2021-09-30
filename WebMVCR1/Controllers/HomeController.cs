using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCR1.Models;

namespace WebMVCR1.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Добрый день";
            ViewData["Mes"] = "хорошего Вам настроения";
            return View();
        }
        [HttpGet]
        public ViewResult InputData()
        {
            return View();
        }

        [HttpPost]
        public ViewResult InputData(Person p)
        {
            personRepo.AddPerson(p);
            return View("Hello", p);
        }

        public ViewResult DataOutput()
        {
            ViewBag.Pers = personRepo.GetAllPeople;
            ViewBag.Count = personRepo.NumberOfPeople;
            return View("ListOfPeople");
        }

        private static PersonRepository personRepo = new PersonRepository();

        //public string Start(string s)
        //{
        //    string greeting = ModelClass.ModelHello() + ", " + s;
        //    return greeting;
        //}
    }
}
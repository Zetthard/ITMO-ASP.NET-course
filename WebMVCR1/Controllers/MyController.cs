using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCR1.Models;

namespace WebMVCR1.Controllers
{
    public class MyController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}
        

        public string Start(string s)
        {
            string greeting = ModelClass.ModelHello() + ", " + s;
            return greeting;
        }
    }
}
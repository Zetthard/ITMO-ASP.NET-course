using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCreditApp.Models;

namespace MVCCreditApp.Controllers
{
    public class HomeController : Controller
    {
        private CreditContext context = new CreditContext();

        public ActionResult Index()
        {
            GetCredits();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void GetCredits()
        {
            var allCredits = context.Credits.ToList();
            ViewBag.Credits = allCredits;
        }

        [HttpGet]
        public ActionResult CreateBid()
        {
            GetCredits();
            var allBids = context.Bids.ToList();
            ViewBag.Bids = allBids;
            return View();
        }

        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.BidDate = DateTime.Now;
            context.Bids.Add(newBid);
            context.SaveChanges();
            return "Спасибо, <b>" + newBid.CustomerName + "</b>, за выбор нашего сайта. Ваша заявка будет рассмотрена в течении 10 дней.";
        }
    }
}
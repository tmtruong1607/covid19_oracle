using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace covid19.Controllers
{
    public class Country
    {

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Country ct = TempData["ct_data"] as Country;
            return View(ct);
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
    }
}
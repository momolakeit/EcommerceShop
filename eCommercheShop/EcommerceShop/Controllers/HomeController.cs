using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceShop.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            ViewBag.featuredItems= Utilitaire.DataManipulation.featuredInitialisation().ToList();
            ViewBag.subFeaturedItems = Utilitaire.DataManipulation.subFeaturedInitialisation();
            ViewBag.DisplayItem = Utilitaire.DataManipulation.ItemDisplayInitialisation();
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
    }
}
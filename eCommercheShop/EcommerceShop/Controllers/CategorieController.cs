using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceShop.Controllers
{
    public class CategorieController : Controller
    {
        static int compteurDisplay = 0;
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult categorieDisplay(Categorie categorie)
        {
            string pos = "carouselDisplayItem" + compteurDisplay;//afin que chaque carousel generer ait un id différent
            ViewBag.compteur = pos;
            
            compteurDisplay++;
            return View(categorie);
        }
    }
}
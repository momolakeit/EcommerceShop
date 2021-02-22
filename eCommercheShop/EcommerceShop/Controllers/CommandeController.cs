using EcommerceShop.Models.DataModel;
using EcommerceShop.Utilitaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EcommerceShop.Controllers
{
    [Authorize]
    public class CommandeController : Controller
    {
        EcommerceDb db;
        
        public CommandeController()
        {
            db = new EcommerceDb();
        }
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult checkOut(int? MyProperty=null,int? nombre = null)
        {
            var clientConnecter = ClientUtilitaire.FindClientParId(db, Int32.Parse(User.Identity.Name));
            if (MyProperty!=null)
            {
                ItemUtilitaire.AjouterItemPanier(db, clientConnecter.clientId, Utilitaire.ItemUtilitaire.findItemById((int)MyProperty).itemId, nombre);
            }
            
            return View(CommandeUtilitaire.nouvelleCommande());
        }
        
        [HttpPost]
        public ActionResult checkOut(Commande c,string CardNumber, string MoisExpiration,string AnneExpiration,string Cvv)
        {
            CommandeUtilitaire.ConfirmerCommande(c,CardNumber,MoisExpiration,AnneExpiration,Cvv);
            return RedirectToAction("Index","Home");
        }
    }
}
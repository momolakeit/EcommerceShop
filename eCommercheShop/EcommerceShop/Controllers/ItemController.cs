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
    public class ItemController : Controller
    {
        public EcommerceDb db;

        public ItemController()
        {
            db = new EcommerceDb();
        }
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ajouterItemAuPanier(int MyProperty,int? nombre=null)
        {
            var clientConnecter = ClientUtilitaire.FindClientParId(db,Int32.Parse( User.Identity.Name));
            ItemUtilitaire.AjouterItemPanier(db, clientConnecter.clientId, Utilitaire.ItemUtilitaire.findItemById(MyProperty).itemId,nombre);
            return RedirectToAction("Index","Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult itemSearch(string motCle,int CategoryId)
        {
            return View(ItemUtilitaire.findItemBySearchQuery(motCle, CategoryId)); 
        }
        [HttpGet]
        public ActionResult panierIndex()
        {
            var client=Utilitaire.ClientUtilitaire.AuthentifiedClient();
           
            return View(client.Panier);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult CategorieDisplay(Categorie categorie)//changere de controller
        {
            var cat = CategorieUtilitaire.findCategorieByiD(db, categorie.CategorieId);
            return View(cat.item);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult ItemDescription(int id )
        {
            return View(DataManipulation.copyItemToItemDetails(ItemUtilitaire.findItemById(id)));
        }
    }
}
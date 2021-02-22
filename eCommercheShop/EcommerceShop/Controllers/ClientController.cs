using EcommerceShop.Models.ViewModel;
using EcommerceShop.Models.DataModel;
using EcommerceShop.Utilitaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net;

namespace EcommerceShop.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        public EcommerceDb db;
        
        public  ClientController()
        {
            db = new EcommerceDb();
        }
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Connection()
        {
          
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Connection(Connection connection)
        {
            if (ModelState.IsValid)
            {
                var client = ClientUtilitaire.TrouverClientConnection(db, connection);
                if (client == null)
                {
                    ViewBag.notFound = true;
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(client.clientId.ToString(), false);
                    ViewBag.notFound = false;
                    return RedirectToAction("Index", "Home"); ;
                }
               
            }


            return View();
        }
        [HttpGet]
        public ActionResult Deconnection()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Inscription()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Inscription(Inscription inscription)
        {
            var client = ClientUtilitaire.AjouterClient(db, inscription);
            if (client == null)
            {
                ViewBag.dejaInscrit = true;
                return View();
            }
            else
            {
                ViewBag.dejaInscrit = false;
                FormsAuthentication.SetAuthCookie(client.clientId.ToString(), false);
                return RedirectToAction("Index", "Home"); 
            }

            
        }
        
        [HttpGet]
        public ActionResult Details(int? id)
        {
            var client = ClientUtilitaire.FindClientParId(db,id.Value);
            if (client == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var clientDetailsView = DataManipulation.copyClientToClientDetailsView(client);
            return View(clientDetailsView);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ClientUtilitaire.DeleteClient(db, id);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DataManipulation.copyClientToClientEditView(  ClientUtilitaire.FindClientParId(db,id)));//retourne ClientEditView
        }

        [HttpPost]
        public ActionResult Edit(ClientEditView clientEditView)
        {
            ClientUtilitaire.EditClient(db, clientEditView);
            return View();
        }
    }
}
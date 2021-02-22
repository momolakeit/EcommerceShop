using EcommerceShop.Models.DataModel;
using EcommerceShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EcommerceShop.Utilitaire
{
    public static class ClientUtilitaire
    {
      
        public static Client TrouverClientConnection(EcommerceDb db,Connection connection)//verifie la connection d'un client
        {
            
            var client= TrouverClientParEmail(db,connection.EmailAdress);
            
            if (client != null)
            {
                if (!(client.Password == connection.Password))
                {
                    client = null;
                }
                
            }
            return client;//retour afin de determiner si on envoi message d'erreur,set cookie,etc
        }

        public static Client TrouverClientParEmail(EcommerceDb db,string emailAdresse)
        {
            var client = db.Clients.Where(s=>s.EmailAdresse==emailAdresse).FirstOrDefault();
            return client;//retourne client afin de set le cookie
        }

        public static Client AjouterClient(EcommerceDb db, Inscription inscription)
        {
            var client = TrouverClientParEmail(db, inscription.EmailAdresse);
            if (client==null)
            {
                client = DataManipulation.copyInscriptionToClient(inscription);
                db.Clients.Add(client);
                db.SaveChanges();
            }
            else
            {
                client = null;//on reset le client a null afin de pouvoir envoyer le  message d'errur car il existe deja dans la bd
            }
            return client;//retour afin de determiner si on envoi message d'erreur,set cookie,etc
        }

        public static Client FindClientParId(EcommerceDb db, int id)
        {
            return db.Clients.Where(s=>s.clientId==id).FirstOrDefault();
        }

        public static void DeleteClient(EcommerceDb db,int id)
        {
            db.Clients.Remove(FindClientParId(db, id));
            db.SaveChanges();
        }

        public static void EditClient(EcommerceDb db,ClientEditView clientEditView)
        {
            var client = db.Clients.Where(s => s.clientId == clientEditView.clientId).FirstOrDefault();
            client.Adresse = clientEditView.Adresse;
            client.EmailAdresse = clientEditView.EmailAdresse;
            client.Nom = clientEditView.Nom;
            client.Password = clientEditView.Password;
            client.Prenom = clientEditView.Prenom;
            client.Province = clientEditView.Province;
            client.Ville = clientEditView.Ville;
            db.SaveChanges();
        }
        public static Client AuthentifiedClient()
        {
            EcommerceDb db = new EcommerceDb();
            int currentClientId =Int32.Parse( System.Web.HttpContext.Current.User.Identity.Name);
            var client = db.Clients.Where(s => s.clientId ==currentClientId).FirstOrDefault();
            return client;
        }
        public static ClientLoggedName LoggedClient()
        {
           
            var client = Utilitaire.DataManipulation.copyClientToClientLoggedName(AuthentifiedClient());
            return client;
        }
    }
}
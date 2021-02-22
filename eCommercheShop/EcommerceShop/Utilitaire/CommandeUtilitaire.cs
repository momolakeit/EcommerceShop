using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceShop.Utilitaire
{
    public static class CommandeUtilitaire
    {
        public static Commande nouvelleCommande()
        {
            EcommerceDb db = new EcommerceDb();
            var clientConnecter = ClientUtilitaire.FindClientParId(db, Int32.Parse(HttpContext.Current.User.Identity.Name));
            Commande c = new Commande();
            c.Items =  clientConnecter.Panier.ToList();
            return c;
        }
        public static void ConfirmerCommande(Commande commande, string CardNumber, string MoisExpiration, string AnneExpiration, string Cvv)
        {
            EcommerceDb db = new EcommerceDb();

           
            commande.dateCommande = DateTime.Now;
            commande.Client = ClientUtilitaire.FindClientParId(db,Int32.Parse(HttpContext.Current.User.Identity.Name));
            commande.Items = commande.Client.Panier.ToList();
            foreach (var i in commande.Items)
            {
                int compt = 0;
                do
                {
                    commande.MontantCommande = i.itemPrice;
                    compt = ++compt;
                } while (compt<i.Quantite);
            }

            CreditCard creditCard = new CreditCard();
            creditCard.CardNumber =Int64.Parse(CardNumber);//changer cardnumber en long
            creditCard.Cvv =Int32.Parse( Cvv);
            creditCard.DateExpiration = new DateTime(Int32.Parse(AnneExpiration), Int32.Parse(MoisExpiration), 1);//sa expire le premierdu mois donc le dernier argument est 1

            commande.CreditCard = creditCard;
           
            db.CreditCards.Add(creditCard);
            db.Commande.Add(commande);

            //db.Commande.Add(new Commande());
            var didi = db.Commande.ToList();

            commande.Client.Panier = null;

            db.SaveChanges();

        }
    }
}
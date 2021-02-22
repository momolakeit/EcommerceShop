using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceShop.Utilitaire
{
    public static class ItemUtilitaire
    {
       public static void AjouterItemPanier(EcommerceDb db,int clientId,int itemId,int? nombreArticle=null)
        {
            var client=  db.Clients.Where(s=>s.clientId==clientId).FirstOrDefault();
            var item = db.Items.Where(s=>s.itemId==itemId).FirstOrDefault();
            if (nombreArticle==null)
            {
                nombreArticle = 1;
            }
            var itemPanier = itemToItemVendu(item);
            itemPanier.Quantite =(int) nombreArticle;
            client.Panier.Add(itemPanier);
            item.quantite =(int) (item.quantite - nombreArticle);
            
         
            db.SaveChanges();
        }
        public static ItemVendu itemToItemVendu(Item item)
        {
            ItemVendu itemVendu = new ItemVendu();
            itemVendu.catgorie = item.catgorie;
            itemVendu.description = item.description;
            itemVendu.ItemCommande = item.ItemCommande;
            itemVendu.itemId = item.itemId;
            itemVendu.itemImageLink = item.itemImageLink;
            itemVendu.itemName = item.itemName;
            itemVendu.itemPrice = item.itemPrice;
            return itemVendu;
        }
        public static double panierTotalPrice(int clientId)
        {
            EcommerceDb db = new EcommerceDb();
            var client = db.Clients.Where(s=>s.clientId==clientId).FirstOrDefault();
            double prixTotal=0;
            foreach (var item in client.Panier)
            {
                int i = 0;
                do//ajuste le prix en fonction du nombre d'articles commandés
                {
                    prixTotal = prixTotal + item.itemPrice;
                    i++;
                } while (i<item.Quantite);
                
               
            }
            return prixTotal;
        }
        public static List<Item> findItemBySearchQuery(string motCle,int categorie)
        {
            EcommerceDb db = new EcommerceDb();
            List<Item> item = db.Items.Where(s => s.itemName == motCle).ToList();
            Categorie c = db.Categories.Where(s => s.nomCategorie == motCle).FirstOrDefault();
            Categorie c2= db.Categories.Where(s => s.CategorieId == categorie).FirstOrDefault();
            List<Item> listFinale =null;
            if (c != null)
            {
                listFinale = item.Union(c.item.ToList()).ToList();
                if (c2 != null)
                {
                    listFinale.Union(c2.item).ToList();
                }
            }
            else if (c2 != null)
            {
                listFinale = item.Union(c2.item).ToList();
            }
            else
            {
                listFinale = item;
            }
            
            return listFinale;
        }
        public static Item findItemById(int id)
        {
            EcommerceDb ecommerceDb = new EcommerceDb();
            var item = ecommerceDb.Items.Where(s => s.itemId == id).FirstOrDefault();
            return item;
        }
    }
}
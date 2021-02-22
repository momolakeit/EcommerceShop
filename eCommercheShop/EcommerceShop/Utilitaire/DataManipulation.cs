using EcommerceShop.Models.DataModel;
using EcommerceShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceShop.Utilitaire
{
    public static class DataManipulation//contien methode copy model view model et methode de trie d'initialisation
    {
        #region copyModelToViewModel
        public static ClientDetailView copyClientToClientDetailsView(Client source)
        {
            var destinataire = new ClientDetailView();
            destinataire.Adresse = source.Adresse;
            destinataire.clientId = source.clientId;
            destinataire.Commandes = source.Commandes;
            destinataire.EmailAdresse = source.EmailAdresse;
            destinataire.Nom = source.Nom;
            destinataire.Prenom = source.Prenom;
            destinataire.Province = source.Province;
            destinataire.Ville = source.Ville;
            return destinataire;
        }

        public static ClientEditView copyClientToClientEditView(Client source)
        {
            ClientEditView destinataire = new ClientEditView();
            destinataire.clientId = source.clientId;
            destinataire.Nom = source.Nom;
            destinataire.Prenom = source.Prenom;
            destinataire.Province = source.Province;
            destinataire.Ville = source.Ville;
            destinataire.Adresse = source.Adresse;
            destinataire.EmailAdresse = source.EmailAdresse;
            destinataire.Password = source.Password;
            return destinataire;
        }
        public static ItemDetails  copyItemToItemDetails(Item source)
        {
            ItemDetails destinataire = new ItemDetails();
            destinataire.itemName = source.itemName;
            destinataire.itemImageLink = source.itemImageLink;
            destinataire.MyProperty = source.itemId;
            destinataire.prix = source.itemPrice;
            return destinataire;
        }
        public static Client copyInscriptionToClient(Inscription source)
        {
            Client destinataire = new Client();
            destinataire.Adresse = source.Adresse;
            destinataire.EmailAdresse = source.EmailAdresse;
            destinataire.Nom = source.Nom;
            destinataire.Password = source.Password;
            destinataire.Prenom = source.Prenom;
            destinataire.Province = source.Province;
            destinataire.Ville = source.Ville;
            return destinataire;
        }
        public static ClientLoggedName copyClientToClientLoggedName(Client source)
        {
            ClientLoggedName clientLoggedName = new ClientLoggedName();
            clientLoggedName.clientPrenom = source.Prenom;
            return clientLoggedName;
        }
        public static List<ItemVendu> copyAllItemsToItemsVendu(List<Item> items) {
            List<ItemVendu> retour = new List<ItemVendu>();
            foreach (var i in items)
            {
                ItemVendu itemVendu = new ItemVendu();
                itemVendu.itemId = i.itemId;
                itemVendu.ItemCommande = i.ItemCommande;
                itemVendu.itemImageLink = i.itemImageLink;
                itemVendu.itemName = i.itemName;
                itemVendu.itemPrice = i.itemPrice;
            }

            return null;

        }
        
        #endregion
        #region Initialisation
        public static List<ItemDetails> featuredInitialisation()
        {
            EcommerceDb db = new EcommerceDb();//on cherche 3 item
            var allItems= db.Items.ToList();
            ItemDetails[] featuredItems = new ItemDetails[3];
            int i = 0;//compteur 
            while(true)
            {
                Random random = new Random();
                int radomItem = random.Next(allItems.Count());
                featuredItems[i] = DataManipulation.copyItemToItemDetails( allItems.ElementAt(radomItem));
                i = ++i;
                if (i == 3)
                {
                    break;
                }
                
            }
            return featuredItems.ToList();
        }
        public static List<Categorie> subFeaturedInitialisation()
        {
            EcommerceDb db = new EcommerceDb();
            var x = db.Items.ToList();
            var allCategorie = db.Categories.ToList();
            Categorie[] subFeaturedCategorie = new Categorie[3];
            int i = 0;
            while(true)
            {
                Random random = new Random();
                int randomCategorie = random.Next(allCategorie.Count());
                var categorieEnvoye= allCategorie.ElementAt(randomCategorie);
                subFeaturedCategorie[i] = allCategorie.ElementAt(randomCategorie);
                Item[] subFeaturedCategoryItem = new Item[4];
                int i2 = 0;
                while (true)
                {
                    int randomItem = random.Next(categorieEnvoye.item.Count());
                    var item = categorieEnvoye.item.ElementAt(randomItem);
                    subFeaturedCategoryItem[i2] = item;
                    
                    i2 = ++i2;
                    if (i2 == 4)
                    {
                        break;
                    }
                }
                categorieEnvoye.item = subFeaturedCategoryItem.ToList();
                subFeaturedCategorie[i] = categorieEnvoye;
                i = ++i;
                if (i == 3)
                {
                    break;
                }
                
            }

            return subFeaturedCategorie.ToList();
        }
        public static List<Categorie> ItemDisplayInitialisation()
        {
            EcommerceDb db = new EcommerceDb();
            var x = db.Items.ToList();
            var allCategorie = db.Categories.ToList();
            Categorie[] subFeaturedCategorie = new Categorie[5];
            int i = 0;
            while (true)
            {
                Random random = new Random();
                int randomCategorie = random.Next(allCategorie.Count());
                var categorieEnvoye = allCategorie.ElementAt(randomCategorie);
                subFeaturedCategorie[i] = allCategorie.ElementAt(randomCategorie);
                subFeaturedCategorie[i] = categorieEnvoye;
                i = ++i;
                if (i == subFeaturedCategorie.Length)
                {
                    break;
                }

            }
            return subFeaturedCategorie.ToList();
        }
        public static Dictionary<int,string> categoryToDictionnary()//permet de creer un dropdown list pour
        {
            EcommerceDb db = new EcommerceDb();
            var allCategory = db.Categories.ToList();
            Dictionary<int, string> dictionnary = new Dictionary<int, string>();
            dictionnary.Add(0,"Categories");
            foreach (var category in allCategory)
            {
                dictionnary.Add(category.CategorieId,category.nomCategorie);
            }
            return dictionnary;
        }
        #endregion

    }
}
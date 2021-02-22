using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceShop.Utilitaire
{
    public static class CategorieUtilitaire
    {
        public static Categorie findCategorieByiD(EcommerceDb db,int id)
        {
            return db.Categories.Where(s => s.CategorieId == id).FirstOrDefault();
        }
    }
}
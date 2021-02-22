using EcommerceShop.Models.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.ViewModel
{
    public class CategorieDisplay
    {
        [Key]
        public int key { get; set; }

        public string nomCategorie { get; set; }

        public List<Item>items{ get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.ViewModel
{
    public class ItemDetails
    {   [Key]
        public int MyProperty { get; set; }

        public string itemName { get; set; }
        
        public string itemImageLink { get; set; }

        public double prix { get; set; }

        public string description { get; set; }
    }
}
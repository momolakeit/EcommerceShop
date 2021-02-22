using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class Item
    {
        [Key]
        public int itemId { get; set; }
        [Required]
        public string itemName { get; set; }

        [Required]
        public Double itemPrice { get; set; }
        [Required]
        public int quantite { get; set; }

        public string description { get; set; }

        [Required]
        public string itemImageLink { get; set; }

        public virtual ICollection<Commande>  ItemCommande { get; set; }

        public virtual Categorie catgorie { get; set; }
        

    }
}
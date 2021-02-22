using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class ItemVendu//creer afin de séparer la quantite d'élément vendue de celle qui est en stock
    {
        [Key]
        public int itemId { get; set; }
        [Required]
        public string itemName { get; set; }

        [Required]
        public Double itemPrice { get; set; }
        [Required]
        public int Quantite { get; set; }

        public string description { get; set; }

        [Required]
        public string itemImageLink { get; set; }

        public virtual ICollection<Commande> ItemCommande { get; set; }

        public virtual Categorie catgorie { get; set; }
    }
}
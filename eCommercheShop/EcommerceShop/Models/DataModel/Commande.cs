using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class Commande
    {
        [Key]
        public int commmandeId { get; set; }
        [Required]
        public DateTime dateCommande { get; set; }

        [Required]
        public Double MontantCommande { get; set; }

        [Required]
        public string nomClientCommande { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Province { get; set; }


        public virtual CreditCard CreditCard { get; set; }///la methode de payment pour la commande
        
        public virtual List<ItemVendu> Items { get; set; }


        public virtual Client Client { get; set; }
       
    }
}
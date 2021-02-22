using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class Client
    {
        [Key]
        public int clientId { get; set; }
        [Required][EmailAddress]
        public string EmailAdresse { get; set; }

        [Required][DataType(DataType.Password)]
        public string Password { get; set; }
          
        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Province { get; set; }

       
        public virtual ICollection<Commande> Commandes { get; set; }
        
        public virtual ICollection<ItemVendu> Panier { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }

    }
}
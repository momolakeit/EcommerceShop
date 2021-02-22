using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        [Required]
        public long CardNumber { get; set; }

        [Required]
        public DateTime DateExpiration { get; set; }

        [Required]
        public int Cvv { get; set; }

       


    }
}
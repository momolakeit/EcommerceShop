using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.ViewModel
{
    public class ClientLoggedName
    {
        [Key]
        public int LoggedNameId { get; set; }

        [Required]
        public string clientPrenom { get; set; }

       
    }
}
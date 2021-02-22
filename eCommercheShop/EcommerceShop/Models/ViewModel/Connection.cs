using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.ViewModel
{
    
    public class Connection
    {
        [Key]
        public int connectId { get; set; }

        [Required][EmailAddress]
        public string EmailAdress { get; set; }

        [Required][DataType(DataType.Password)]
        public string Password { get; set; }


        public bool Souvenir { get; set; }
        
    }
}
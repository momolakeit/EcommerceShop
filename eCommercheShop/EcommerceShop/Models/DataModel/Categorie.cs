using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.DataModel
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Required]
        public string nomCategorie { get; set; }

        public virtual ICollection<Item> item { get; set; }
    }
}
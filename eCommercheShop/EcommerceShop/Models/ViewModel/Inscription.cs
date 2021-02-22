using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceShop.Models.ViewModel
{
    [CustomValidation(typeof(Inscription),"Valider")]
    public class Inscription
    {
        [Key]
        public int clientId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdresse { get; set; }

        [EmailAddress]
        public string EmailAdresseConfirmation { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }


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

        public static ValidationResult Valider(Inscription i)
        {
            if (i.Password != i.PasswordConfirmation)
            {
                return new ValidationResult("Mot De Passe Différents",new[] { "Password", "PasswordConfirmation" });
            }
            if(i.EmailAdresse!= i.EmailAdresseConfirmation)
            {
                return new ValidationResult("Email différent", new[] { "EmailAdresse", "EmailAdresseConfirmation" });
            }
            else
            {
                return ValidationResult.Success;
            }
        }
       
    }
}
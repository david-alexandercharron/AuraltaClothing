using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.ShoppingCart
{
    public class CheckoutVM : ShoppingCartVM
    {

        [Required(ErrorMessage = "The Street Address is required")]
        public string line1 { get; set; }

        [Required(ErrorMessage = "The City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "The State is required")]
        public string state { get; set; }

        //[Required]
        public string country_code { get; set; }

        [Required(ErrorMessage = "The Postal Code is required")]
        // Check USA Zip code or Canada Postal Code
        [RegularExpression(@"(([ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz] ?[0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz][0-9])|(^\d{5}(?:[-\s]\d{4})?$))", ErrorMessage = "The postal code must be valid")]
        public string postal_code { get; set; }

    }
}
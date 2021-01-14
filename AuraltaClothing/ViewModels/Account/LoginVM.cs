using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Account
{
    public class LoginVM
    {

        [Required(ErrorMessage = "The Email is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The Email is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
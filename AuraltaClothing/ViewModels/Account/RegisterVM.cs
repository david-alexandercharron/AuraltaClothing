using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Account
{
    public class RegisterVM
    {

        // If you change something here, change it aswell in LoginRegisterForgotPasswordVM

        [StringLength(256, ErrorMessage = "The first name must be a maximum length of 256 caracters.")]
        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; }

        [StringLength(256, ErrorMessage = "The last name must be a maximum length of 256 caracters.")]
        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "The Email is not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string RegisterEmail { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("RegisterPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string RegisterConfirmPassword { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Manage
{
    public class AccountVM
    {
        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool HasPassword { get; set; }

        [Required(ErrorMessage = "The Current Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
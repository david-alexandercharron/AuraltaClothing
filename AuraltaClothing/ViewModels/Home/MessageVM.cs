using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Home
{
    public class MessageVM
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The description is required")]
        public string Description { get; set; }

    }
}
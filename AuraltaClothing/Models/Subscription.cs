using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class Subscription
    {

        public int SubscriptionId { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [StringLength(256, ErrorMessage = "The email must be a maximum length of 256 caracters.")]
        public string Email { get; set; }

    }
}
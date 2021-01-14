using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Administration
{
    public class AdministrationVM
    {

        public List<Order> Orders { get; set; }

        public List<Message> Messages { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<Subscription> Subscriptions { get; set; }

    }
}
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Home
{
    public class HomeVM
    {

        public List<Product> Products { get; set; }

        public string CurrencyCode { get; set; }

    }
}
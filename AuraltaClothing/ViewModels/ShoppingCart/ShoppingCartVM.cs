using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.ShoppingCart
{
    public class ShoppingCartVM
    {

        public ShoppingCartVM()
        {
            Products = new List<Models.ShoppingCartProduct>();
        }

        public List<Models.ShoppingCartProduct> Products { get; set; }

        public double Subtotal { get; set; }

        public string CurrencyCode { get; set; }

        public string CountryCode { get; set; }

        [NotMapped]
        public double Total
        {
            get {
                return Subtotal;
            }
        }

    }
}
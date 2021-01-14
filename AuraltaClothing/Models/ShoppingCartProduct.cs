using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class ShoppingCartProduct
    {

        public int ShoppingCartProductId { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ProductSize Size { get; set; }

        public int Quantity { get; set; }

    }
}
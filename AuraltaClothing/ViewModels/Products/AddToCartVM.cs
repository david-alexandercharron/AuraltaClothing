using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Products
{
    public class CartVM
    {

        public int ProductId { get; set; }

        public ProductSize Size { get; set; }

        public int Quantity { get; set; }

    }
}
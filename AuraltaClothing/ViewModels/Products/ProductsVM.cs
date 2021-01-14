using AuraltaClothing.Enums;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Products
{
    public class ProductsVM
    {

        public ProductCategory Category { get; set; }

        public List<Product> Products { get; set; }

        public string CurrencyCode { get; set; }

    }
}
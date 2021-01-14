using AuraltaClothing.Enums;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.ViewModels.Products
{
    public class ProductVM
    {

        public Product Product { get; set; }

        public ProductSize Size { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "The quantity must be at least one.")]
        public int Quantity { get; set; }

        public string CurrencyCode { get; set; }
    }
}
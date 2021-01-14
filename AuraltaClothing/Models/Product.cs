
using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double PriceUSD { get; set; }

        public string GeneralImagePath { get; set; }

        public string Description { get; set; }

        public ProductCategory Category { get; set; }

        public ProductColor Color { get; set; }

        public Gender Gender { get; set; }

        public ProductLogo Logo { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }

    }
}
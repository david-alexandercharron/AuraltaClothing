using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class ProductOrder
    {

        public int ProductOrderId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ProductSize Size { get; set; }

        public int Quantity { get; set; }

    }
}
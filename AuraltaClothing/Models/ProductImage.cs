using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class ProductImage
    {

        public int ProductImageId { get; set; }

        [Required(ErrorMessage = "The image is required")]
        public string ImagePath { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
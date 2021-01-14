namespace AuraltaClothing.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<AuraltaClothing.Models.AuraltaClothingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.AuraltaClothingDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //dbContext.Products.RemoveRange(dbContext.Products.ToList());

            List<Models.Product> products = new List<Models.Product>()
            {

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Hoodie Premium Auralta - Sandstorm",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium Auralta - Sandstorm/Hoodie Premium Auralta - Sandstorm.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta Premium logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Hoodie Premium Auralta - White Lifestyle",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium Auralta - White Lifestyle/Hoodie Premium Auralta - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta Premium logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Hoodie Premium Auralta - Black Lifestyle",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium Auralta - Black Lifestyle/Hoodie Premium Auralta - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta Premium logo in White</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Hoodie Premium Auralta - Red Maroon",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium Auralta - Red Maroon/Hoodie Premium Auralta - Red Maroon.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta Premium logo in White</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Hoodie Premium RTYP - Black Camo",
                    Price = 76.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium RTYP - Black Camo/Hoodie Premium RTYP - Black Camo.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Hoodie Premium RTYP - Black Lifestyle",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium RTYP - Black Lifestyle/Hoodie Premium RTYP - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Hoodie Premium RTYP - White Lifestyle",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium RTYP - White Lifestyle/Hoodie Premium RTYP - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.Hoodie,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Hoodie Premium RTYP - Royal Blue",
                    Price = 64.99,
                    GeneralImagePath = "/Images/Products/Hoodies/Premium RTYP - Royal Blue/Hoodie Premium RTYP - Royal Blue.png",
                    Description = "<p>Rise To Your Potential with a great selection of hoodies to fit your lifestyle.</p><p>- 80% cotton - 20% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- Midweight hoodie</p><p>- 14.1 oz Hoodie</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.LongSleeve,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Long Sleeves Auralta - Black Lifestyle",
                    Price = 39.99,
                    GeneralImagePath = "/Images/Products/Long sleeves/Auralta - Black Lifestyle/Long Sleeves Auralta - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of long sleeves to fit your lifestyle.</p><p>- 60% cotton - 40% polyster</p><p>- Auralta Premium logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz Long Sleeve</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.LongSleeve,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "Long Sleeves Auralta - White Lifestyle",
                    Price = 39.99,
                    GeneralImagePath = "/Images/Products/Long sleeves/Auralta - White Lifestyle/Long Sleeves Auralta - White lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of long sleeves to fit your lifestyle.</p><p>- 60% cotton - 40% polyster</p><p>- Auralta Premium logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz Long Sleeve</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.LongSleeve,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Long Sleeves RTYP - Black Lifestyle",
                    Price = 39.99,
                    GeneralImagePath = "/Images/Products/Long sleeves/RTYP - Black Lifestyle/Long Sleeves RTYP - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of long sleeves to fit your lifestyle.</p><p>- 60% cotton - 40% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz Long Sleeve</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.LongSleeve,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Long Sleeves RTYP - White Lifestyle",
                    Price = 39.99,
                    GeneralImagePath = "/Images/Products/Long sleeves/RTYP - White Lifestyle/Long Sleeves RTYP - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of long sleeves to fit your lifestyle.</p><p>- 60% cotton - 40% polyster</p><p>- Auralta ''Rise to Your Potential'' logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz Long Sleeve</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.PocketTShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Pocket T-Shirt RTYP - Beige Sand",
                    Price = 34.99,
                    GeneralImagePath = "/Images/Products/Pocket t-shirts/RTYP - Beige Sand/Pocket T-Shirt RTYP - Beige Sand.png",
                    Description = "<p>Rise To Your Potential with a great selection of Pocket T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 10 oz Pocket T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.PocketTShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Pocket T-Shirt RTYP - Black Lifestyle",
                    Price = 34.99,
                    GeneralImagePath = "/Images/Products/Pocket t-shirts/RTYP - Black Lifestyle/Pocket T-Shirt RTYP - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of Pocket T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 10 oz Pocket T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.PocketTShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "Pocket T-Shirt RTYP - White Lifestyle",
                    Price = 34.99,
                    GeneralImagePath = "/Images/Products/Pocket t-shirts/RTYP - White Lifestyle/Pocket T-Shirt RTYP - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of Pocket T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 10 oz Pocket T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "T-Shirt Premium Auralta - Blue Ocean",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium Auralta - Blue Ocean/T-Shirt Premium Auralta - Blue Ocean.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 60% cotton/40% polyester</p><p>- Auralta Premium logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "T-Shirt Premium Auralta - White Lifestyle",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium Auralta - White Lifestyle/T-Shirt Premium Auralta - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta Premium logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.AuraltaLogo,
                    Name = "T-Shirt Premium Auralta - Black Lifestyle",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium Auralta - Black Lifestyle/T-Shirt Premium Auralta - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta Premium logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "T-Shirt Premium RTYP - Black Lifestyle",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium RTYP - Black Lifestyle/T-Shirt Premium RTYP - Black Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "T-Shirt Premium RTYP - Blue Navy",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium RTYP - Blue Navy/T-Shirt Premium RTYP - Blue Navy.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "T-Shirt Premium RTYP - Grey Smoke",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium RTYP - Grey Smoke/T-Shirt Premium RTYP - Grey Smoke.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },
                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "T-Shirt Premium RTYP - White Lifestyle",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium RTYP - White Lifestyle/T-Shirt Premium RTYP - White Lifestyle.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in Black</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },

                new Models.Product()
                {
                    Category = ProductCategory.TShirt,
                    Gender = Gender.Unisex,
                    Logo = Enums.ProductLogo.RiseToYourPotential,
                    Name = "T-Shirt Premium RTYP - Motivational Red",
                    Price = 29.99,
                    GeneralImagePath = "/Images/Products/T-shirts/Premium RTYP - Motivational Red/T-Shirt Premium RTYP - Motivational Red.png",
                    Description = "<p>Rise To Your Potential with a great selection of T-shirts to fit your lifestyle.</p><p>- 100% cotton</p><p>- Auralta ''Rise to Your Potential'' logo in White</p><p>- Comfortable feeling and stylish look </p><p>- 6.8 oz T-shirt</p>"
                },



            };

            //dbContext.Products.AddRange(products);

            //dbContext.SaveChanges();


        }
    }
}

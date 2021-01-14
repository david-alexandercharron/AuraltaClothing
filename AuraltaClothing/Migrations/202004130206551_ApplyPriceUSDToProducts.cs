namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyPriceUSDToProducts : DbMigration
    {
        public override void Up()
        {

            Models.AuraltaClothingDbContext dbContext = new Models.AuraltaClothingDbContext();

            foreach (Models.Product product in dbContext.Products)
            {
                if (product.ProductId == 350)
                    product.PriceUSD = 57.99;
                else if (product.Category == Enums.ProductCategory.Hoodie)
                    product.PriceUSD = 49.99;
                else if (product.Category == Enums.ProductCategory.TShirt)
                    product.PriceUSD = 23.99;
                else if (product.Category == Enums.ProductCategory.LongSleeve)
                    product.PriceUSD = 29.99;
                else if (product.Category == Enums.ProductCategory.PocketTShirt)
                    product.PriceUSD = 27.99;


                //dbContext.Products.AddOrUpdate(product);
            }


            dbContext.SaveChanges();
        }
        
        public override void Down()
        {
        }
    }
}

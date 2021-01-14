namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePrices : DbMigration
    {
        public override void Up()
        {
            Models.AuraltaClothingDbContext dbContext = new Models.AuraltaClothingDbContext();

            foreach (Models.Product product in dbContext.Products)
            {
                if (product.ProductId == 350)
                    product.PriceUSD = 64.99;
                else if (product.Category == Enums.ProductCategory.Hoodie)
                {
                    product.Price = 49.99;
                    product.PriceUSD = 39.99;
                }
                


            }


            dbContext.SaveChanges();
        }
        
        public override void Down()
        {
        }
    }
}

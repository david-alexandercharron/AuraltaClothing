namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePrices1 : DbMigration
    {
        public override void Up()
        {
            Models.AuraltaClothingDbContext dbContext = new Models.AuraltaClothingDbContext();

            foreach (Models.Product product in dbContext.Products)
            {
                if (product.ProductId == 350)
                {
                    product.Price = 64.99;
                    product.PriceUSD = 49.99;

                }
            }


            dbContext.SaveChanges();
        }
        
        public override void Down()
        {
        }
    }
}

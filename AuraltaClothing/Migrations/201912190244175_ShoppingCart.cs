namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartProducts",
                c => new
                    {
                        ShoppingCartProductId = c.Int(nullable: false, identity: true),
                        ShoppingCartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartProductId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ShoppingCartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartProducts", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCartProducts", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCartProducts", new[] { "ShoppingCartId" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ShoppingCartProducts");
        }
    }
}

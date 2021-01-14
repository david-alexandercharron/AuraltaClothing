namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ShoppingCartId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ShoppingCartId");
            AddForeignKey("dbo.AspNetUsers", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.AspNetUsers", new[] { "ShoppingCartId" });
            DropColumn("dbo.AspNetUsers", "ShoppingCartId");
        }
    }
}

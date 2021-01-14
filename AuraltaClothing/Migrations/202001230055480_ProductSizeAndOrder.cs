namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductSizeAndOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCartProducts", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCartProducts", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCartProducts", "Quantity");
            DropColumn("dbo.ShoppingCartProducts", "Size");
        }
    }
}

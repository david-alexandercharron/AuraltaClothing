namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        ProductOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOrderId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "OrderId", "dbo.Orders");
            DropIndex("dbo.ProductOrders", new[] { "ProductId" });
            DropIndex("dbo.ProductOrders", new[] { "OrderId" });
            DropTable("dbo.ProductOrders");
        }
    }
}

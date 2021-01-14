namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductOrders", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.ProductOrders", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Total", c => c.String());
            DropColumn("dbo.Orders", "AddressTwo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "AddressTwo", c => c.String());
            AlterColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
            DropColumn("dbo.ProductOrders", "Quantity");
            DropColumn("dbo.ProductOrders", "Size");
            DropColumn("dbo.Orders", "Date");
        }
    }
}

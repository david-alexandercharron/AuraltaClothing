namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder_ShippingInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PayId", c => c.String());
            AddColumn("dbo.Orders", "City", c => c.String());
            AddColumn("dbo.Orders", "CountryCode", c => c.String());
            AddColumn("dbo.Orders", "AddressOne", c => c.String());
            AddColumn("dbo.Orders", "AddressTwo", c => c.String());
            AddColumn("dbo.Orders", "PostalCode", c => c.String());
            AddColumn("dbo.Orders", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "AddressTwo");
            DropColumn("dbo.Orders", "AddressOne");
            DropColumn("dbo.Orders", "CountryCode");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "PayId");
        }
    }
}

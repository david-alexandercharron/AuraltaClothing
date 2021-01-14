namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder_Pricing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Currency", c => c.String());
            AddColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Currency");
        }
    }
}

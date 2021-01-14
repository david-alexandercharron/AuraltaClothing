namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder_ClientNameEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
        }
    }
}

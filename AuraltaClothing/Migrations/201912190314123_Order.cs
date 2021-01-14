namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        ClientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.Orders");
        }
    }
}

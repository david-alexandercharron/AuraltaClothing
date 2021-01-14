namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscriptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriptions");
        }
    }
}

namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductLogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Logo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Logo");
        }
    }
}

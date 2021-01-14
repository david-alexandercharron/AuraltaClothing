namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Categorie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Categorie", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Gender");
            DropColumn("dbo.Products", "Category");
        }
    }
}

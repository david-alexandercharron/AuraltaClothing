namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FirstName", c => c.String());
            AddColumn("dbo.Messages", "LastName", c => c.String());
            DropColumn("dbo.Messages", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FullName", c => c.String());
            DropColumn("dbo.Messages", "LastName");
            DropColumn("dbo.Messages", "FirstName");
        }
    }
}

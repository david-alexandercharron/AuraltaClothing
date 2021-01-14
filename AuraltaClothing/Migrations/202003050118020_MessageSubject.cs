namespace AuraltaClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageSubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Subject", c => c.String());
            DropColumn("dbo.Messages", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Title", c => c.String());
            DropColumn("dbo.Messages", "Subject");
        }
    }
}

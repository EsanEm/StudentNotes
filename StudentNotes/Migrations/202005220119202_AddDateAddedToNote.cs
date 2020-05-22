namespace StudentNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "DateAdded");
        }
    }
}

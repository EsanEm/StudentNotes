namespace StudentNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Students",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
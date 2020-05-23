namespace StudentNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddNote1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Notes",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProgressRating = c.Byte(nullable: false),
                        ExtraNote = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Notes", "StudentId", "dbo.Students");
            DropIndex("dbo.Notes", new[] {"StudentId"});
            DropTable("dbo.Notes");
        }
    }
}
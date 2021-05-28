namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mainedit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedLessons",
                c => new
                    {
                        IdSelectedLesson = c.Int(nullable: false, identity: true),
                        IdLesson = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSelectedLesson)
                .ForeignKey("dbo.Lessons", t => t.IdLesson, cascadeDelete: true)
                .ForeignKey("dbo.MyUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.IdLesson)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        IdLesson = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Vahed = c.Int(nullable: false),
                        MasterName = c.String(),
                    })
                .PrimaryKey(t => t.IdLesson);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelectedLessons", "UserId", "dbo.MyUsers");
            DropForeignKey("dbo.SelectedLessons", "IdLesson", "dbo.Lessons");
            DropIndex("dbo.SelectedLessons", new[] { "UserId" });
            DropIndex("dbo.SelectedLessons", new[] { "IdLesson" });
            DropTable("dbo.Lessons");
            DropTable("dbo.SelectedLessons");
        }
    }
}

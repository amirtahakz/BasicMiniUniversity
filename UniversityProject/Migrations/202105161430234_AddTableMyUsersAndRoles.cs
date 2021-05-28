namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CodeMelly = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RePassword = c.String(nullable: false),
                        IdRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.IdRole, cascadeDelete: true)
                .Index(t => t.IdRole);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRole = c.Int(nullable: false),
                        NameFarsi = c.String(),
                        NameEnglish = c.String(),
                    })
                .PrimaryKey(t => t.IdRole);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            DropTable("dbo.Roles");
            DropTable("dbo.MyUsers");
        }
    }
}

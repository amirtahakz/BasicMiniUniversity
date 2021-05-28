namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            AlterColumn("dbo.MyUsers", "IdRole", c => c.Int());
            CreateIndex("dbo.MyUsers", "IdRole");
            AddForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles", "IdRole");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            AlterColumn("dbo.MyUsers", "IdRole", c => c.Int(nullable: false));
            CreateIndex("dbo.MyUsers", "IdRole");
            AddForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles", "IdRole", cascadeDelete: true);
        }
    }
}

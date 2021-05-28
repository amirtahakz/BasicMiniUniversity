namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            AlterColumn("dbo.MyUsers", "CodeMelly", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "RePassword", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "IdRole", c => c.Int(nullable: false));
            CreateIndex("dbo.MyUsers", "IdRole");
            AddForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles", "IdRole", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            AlterColumn("dbo.MyUsers", "IdRole", c => c.Int());
            AlterColumn("dbo.MyUsers", "RePassword", c => c.String());
            AlterColumn("dbo.MyUsers", "Password", c => c.String());
            AlterColumn("dbo.MyUsers", "FullName", c => c.String());
            AlterColumn("dbo.MyUsers", "CodeMelly", c => c.String());
            CreateIndex("dbo.MyUsers", "IdRole");
            AddForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles", "IdRole");
        }
    }
}

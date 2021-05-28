namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyUsers", "CodeMelly", c => c.String());
            AlterColumn("dbo.MyUsers", "FullName", c => c.String());
            AlterColumn("dbo.MyUsers", "Password", c => c.String());
            AlterColumn("dbo.MyUsers", "RePassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyUsers", "RePassword", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.MyUsers", "CodeMelly", c => c.String(nullable: false));
        }
    }
}

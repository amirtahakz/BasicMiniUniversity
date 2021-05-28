namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namerl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "NameRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyUsers", "NameRole");
        }
    }
}

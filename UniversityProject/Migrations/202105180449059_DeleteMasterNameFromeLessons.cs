namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lll : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lessons", "MasterName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "MasterName", c => c.String());
        }
    }
}

namespace UniversityProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteNameRoleFromMyUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MyUsers", "NameRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyUsers", "NameRole", c => c.String());
        }
    }
}

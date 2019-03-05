namespace ITI.Mvc.LinkedIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ahmed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "LinkedInUserId", c => c.String());
            AddColumn("dbo.Companies", "Title", c => c.String());
            AddColumn("dbo.Companies", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "EndDate");
            DropColumn("dbo.Companies", "StartDate");
            DropColumn("dbo.Companies", "Title");
            DropColumn("dbo.Companies", "LinkedInUserId");
        }
    }
}

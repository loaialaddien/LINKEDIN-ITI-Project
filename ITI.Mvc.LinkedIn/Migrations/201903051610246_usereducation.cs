namespace ITI.Mvc.LinkedIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usereducation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEducations", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.UserEducations", "UniversityId", "dbo.Universities");
            DropIndex("dbo.UserEducations", new[] { "UniversityId" });
            DropIndex("dbo.UserEducations", new[] { "FacultyId" });
            AddColumn("dbo.UserEducations", "University", c => c.String());
            AddColumn("dbo.UserEducations", "Fieldofstudy", c => c.String());
            AddColumn("dbo.UserEducations", "Grade", c => c.String());
            AddColumn("dbo.UserEducations", "Activities", c => c.String());
            AddColumn("dbo.UserEducations", "Descriptions", c => c.String());
            AddColumn("dbo.UserEducations", "StartingDate", c => c.Int(nullable: false));
            AddColumn("dbo.UserEducations", "EndDate", c => c.Int(nullable: false));
            DropColumn("dbo.UserEducations", "UniversityId");
            DropColumn("dbo.UserEducations", "FacultyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserEducations", "FacultyId", c => c.Int(nullable: false));
            AddColumn("dbo.UserEducations", "UniversityId", c => c.Int(nullable: false));
            DropColumn("dbo.UserEducations", "EndDate");
            DropColumn("dbo.UserEducations", "StartingDate");
            DropColumn("dbo.UserEducations", "Descriptions");
            DropColumn("dbo.UserEducations", "Activities");
            DropColumn("dbo.UserEducations", "Grade");
            DropColumn("dbo.UserEducations", "Fieldofstudy");
            DropColumn("dbo.UserEducations", "University");
            CreateIndex("dbo.UserEducations", "FacultyId");
            CreateIndex("dbo.UserEducations", "UniversityId");
            AddForeignKey("dbo.UserEducations", "UniversityId", "dbo.Universities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserEducations", "FacultyId", "dbo.Faculties", "Id", cascadeDelete: true);
        }
    }
}

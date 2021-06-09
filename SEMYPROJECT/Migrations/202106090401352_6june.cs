namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6june : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ProvoinceID", c => c.String());
            AddColumn("dbo.Students", "CityID", c => c.String());
            AddColumn("dbo.Students", "SchoolID", c => c.Int());
            AddColumn("dbo.Students", "MajorID", c => c.Int());
            AddColumn("dbo.Students", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Discriminator");
            DropColumn("dbo.Students", "MajorID");
            DropColumn("dbo.Students", "SchoolID");
            DropColumn("dbo.Students", "CityID");
            DropColumn("dbo.Students", "ProvoinceID");
        }
    }
}

namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ProvinceID", c => c.String());
            DropColumn("dbo.Students", "ProvoinceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ProvoinceID", c => c.String());
            DropColumn("dbo.Students", "ProvinceID");
        }
    }
}

namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.templateinprovince", newName: "Provinces");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Provinces", newName: "templateinprovince");
        }
    }
}

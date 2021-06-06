namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.city", newName: "Cities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cities", newName: "city");
        }
    }
}

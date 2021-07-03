namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb9 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

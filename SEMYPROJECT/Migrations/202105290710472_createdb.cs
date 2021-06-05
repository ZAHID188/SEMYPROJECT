namespace SEMYPROJECT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 20),
                        GenderNo = c.Byte(nullable: false),
                        Remark = c.String(maxLength: 200),
                        PhotoPath = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.AuthorID)
                .ForeignKey("dbo.Genders", t => t.GenderNo)
                .Index(t => t.GenderNo);
            
            CreateTable(
                "dbo.BookInfoes",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        BookName = c.String(nullable: false, maxLength: 50),
                        ISBN = c.String(nullable: false, maxLength: 20),
                        PressID = c.Int(nullable: false),
                        Price = c.Double(),
                        AuthorID = c.Int(nullable: false),
                        PublishDate = c.DateTime(),
                        Version = c.Short(),
                        CoverPath = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.BookCategories", t => t.CategoryID)
                .ForeignKey("dbo.Presses", t => t.PressID)
                .Index(t => t.CategoryID)
                .Index(t => t.PressID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Presses",
                c => new
                    {
                        PressID = c.Int(nullable: false),
                        PressName = c.String(nullable: false, maxLength: 20),
                        CityID = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PressID)
                .ForeignKey("dbo.city", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.city",
                c => new
                    {
                        CityID = c.String(nullable: false, maxLength: 20),
                        CityName = c.String(nullable: false, maxLength: 20),
                        ProvinceID = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.templateinprovince", t => t.ProvinceID)
                .Index(t => new { t.ProvinceID, t.CityName }, unique: true, name: "IX_city_cityName");
            
            CreateTable(
                "dbo.templateinprovince",
                c => new
                    {
                        ProvinceID = c.String(nullable: false, maxLength: 15),
                        ProvinceName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ProvinceID)
                .Index(t => t.ProvinceName, unique: true, name: "IX_Province_ProvinceName");
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderNo = c.Byte(nullable: false),
                        GenderName = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.GenderNo)
                .Index(t => t.GenderName, unique: true, name: "IX_Gender_GenderName");
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SNo = c.String(nullable: false, maxLength: 11),
                        SName = c.String(nullable: false, maxLength: 12),
                        GenderNo = c.Byte(nullable: false),
                        BornDate = c.DateTime(nullable: false),
                        BornCountyID = c.String(nullable: false, maxLength: 15),
                        QQ = c.String(nullable: false, maxLength: 15),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Email = c.String(nullable: false, maxLength: 30),
                        AvatarPath = c.String(maxLength: 50),
                        PhotoData = c.Binary(),
                        PhotoMimeType = c.String(),
                        ClassNo = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.SNo)
                .ForeignKey("dbo.Classes", t => t.ClassNo)
                .ForeignKey("dbo.Counties", t => t.BornCountyID)
                .ForeignKey("dbo.Genders", t => t.GenderNo)
                .Index(t => t.GenderNo)
                .Index(t => t.BornCountyID)
                .Index(t => t.QQ, unique: true, name: "IDX_Student_QQ")
                .Index(t => t.Phone, unique: true, name: "IX_Student_Phone")
                .Index(t => t.Email, unique: true, name: "IX_Student_Email")
                .Index(t => t.ClassNo);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassNo = c.String(nullable: false, maxLength: 8),
                        ClassName = c.String(nullable: false, maxLength: 10),
                        MajorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassNo)
                .ForeignKey("dbo.YzuMajors", t => t.MajorID)
                .Index(t => t.ClassName, unique: true, name: "IX_Class_ClassName")
                .Index(t => t.MajorID);
            
            CreateTable(
                "dbo.YzuMajors",
                c => new
                    {
                        MajorID = c.Int(nullable: false),
                        MajorName = c.String(nullable: false, maxLength: 20),
                        SchoolID = c.Int(nullable: false),
                        MajorJianPin = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.MajorID)
                .ForeignKey("dbo.YzuSchools", t => t.SchoolID)
                .Index(t => new { t.SchoolID, t.MajorName }, unique: true, name: "IX_Major_MajorName");
            
            CreateTable(
                "dbo.YzuSchools",
                c => new
                    {
                        SchoolID = c.Int(nullable: false),
                        SchoolName = c.String(nullable: false, maxLength: 20),
                        SchoolJianPin = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.SchoolID)
                .Index(t => t.SchoolName, unique: true, name: "IX_School_SchoolName");
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        CountyID = c.String(nullable: false, maxLength: 15),
                        CountyName = c.String(nullable: false, maxLength: 20),
                        CityID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CountyID)
                .ForeignKey("dbo.city", t => t.CityID)
                .Index(t => new { t.CityID, t.CountyName }, unique: true, name: "IX_County_CountyName");
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SNo = c.String(nullable: false, maxLength: 11),
                        CNo = c.String(nullable: false, maxLength: 12),
                        Mark = c.Short(),
                        Remark = c.String(maxLength: 10),
                        DateOfExam = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CNo)
                .ForeignKey("dbo.Students", t => t.SNo)
                .Index(t => new { t.SNo, t.CNo }, unique: true, name: "IX_Score_SNo_CNo");
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CNo = c.String(nullable: false, maxLength: 12),
                        CName = c.String(nullable: false, maxLength: 20),
                        ClassPeriods = c.Byte(nullable: false),
                        ExperimentPeriods = c.Byte(nullable: false),
                        CourseTypeNo = c.Byte(nullable: false),
                        Credit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CNo)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeNo)
                .Index(t => t.CourseTypeNo);
            
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        CourseTypeNo = c.Byte(nullable: false),
                        CourseTypeName = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.CourseTypeNo)
                .Index(t => t.CourseTypeName, unique: true, name: "IX_CourseType_CourseTypeName");
            
            CreateTable(
                "dbo.XUsers",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        GenderNo = c.Byte(nullable: false),
                        Pwd = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Email = c.String(nullable: false, maxLength: 30),
                        BornDate = c.String(nullable: false, maxLength: 10),
                        Remark = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Genders", t => t.GenderNo)
                .Index(t => t.GenderNo)
                .Index(t => t.Phone, unique: true, name: "IX_User_Phone")
                .Index(t => t.Email, unique: true, name: "IX_User_Email");
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleWithControllerActions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AreaName = c.String(maxLength: 20),
                        ControllerName = c.String(nullable: false, maxLength: 30),
                        ActionName = c.String(nullable: false, maxLength: 30),
                        RoleIds = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Authors", "GenderNo", "dbo.Genders");
            DropForeignKey("dbo.XUsers", "GenderNo", "dbo.Genders");
            DropForeignKey("dbo.Scores", "SNo", "dbo.Students");
            DropForeignKey("dbo.Scores", "CNo", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseTypeNo", "dbo.CourseTypes");
            DropForeignKey("dbo.Students", "GenderNo", "dbo.Genders");
            DropForeignKey("dbo.Students", "BornCountyID", "dbo.Counties");
            DropForeignKey("dbo.Counties", "CityID", "dbo.city");
            DropForeignKey("dbo.Students", "ClassNo", "dbo.Classes");
            DropForeignKey("dbo.YzuMajors", "SchoolID", "dbo.YzuSchools");
            DropForeignKey("dbo.Classes", "MajorID", "dbo.YzuMajors");
            DropForeignKey("dbo.Presses", "CityID", "dbo.city");
            DropForeignKey("dbo.city", "ProvinceID", "dbo.templateinprovince");
            DropForeignKey("dbo.BookInfoes", "PressID", "dbo.Presses");
            DropForeignKey("dbo.BookInfoes", "CategoryID", "dbo.BookCategories");
            DropForeignKey("dbo.BookInfoes", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.XUsers", "IX_User_Email");
            DropIndex("dbo.XUsers", "IX_User_Phone");
            DropIndex("dbo.XUsers", new[] { "GenderNo" });
            DropIndex("dbo.CourseTypes", "IX_CourseType_CourseTypeName");
            DropIndex("dbo.Courses", new[] { "CourseTypeNo" });
            DropIndex("dbo.Scores", "IX_Score_SNo_CNo");
            DropIndex("dbo.Counties", "IX_County_CountyName");
            DropIndex("dbo.YzuSchools", "IX_School_SchoolName");
            DropIndex("dbo.YzuMajors", "IX_Major_MajorName");
            DropIndex("dbo.Classes", new[] { "MajorID" });
            DropIndex("dbo.Classes", "IX_Class_ClassName");
            DropIndex("dbo.Students", new[] { "ClassNo" });
            DropIndex("dbo.Students", "IX_Student_Email");
            DropIndex("dbo.Students", "IX_Student_Phone");
            DropIndex("dbo.Students", "IDX_Student_QQ");
            DropIndex("dbo.Students", new[] { "BornCountyID" });
            DropIndex("dbo.Students", new[] { "GenderNo" });
            DropIndex("dbo.Genders", "IX_Gender_GenderName");
            DropIndex("dbo.templateinprovince", "IX_Province_ProvinceName");
            DropIndex("dbo.city", "IX_city_cityName");
            DropIndex("dbo.Presses", new[] { "CityID" });
            DropIndex("dbo.BookInfoes", new[] { "AuthorID" });
            DropIndex("dbo.BookInfoes", new[] { "PressID" });
            DropIndex("dbo.BookInfoes", new[] { "CategoryID" });
            DropIndex("dbo.Authors", new[] { "GenderNo" });
            DropTable("dbo.RoleWithControllerActions");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.XUsers");
            DropTable("dbo.CourseTypes");
            DropTable("dbo.Courses");
            DropTable("dbo.Scores");
            DropTable("dbo.Counties");
            DropTable("dbo.YzuSchools");
            DropTable("dbo.YzuMajors");
            DropTable("dbo.Classes");
            DropTable("dbo.Students");
            DropTable("dbo.Genders");
            DropTable("dbo.templateinprovince");
            DropTable("dbo.city");
            DropTable("dbo.Presses");
            DropTable("dbo.BookCategories");
            DropTable("dbo.BookInfoes");
            DropTable("dbo.Authors");
        }
    }
}

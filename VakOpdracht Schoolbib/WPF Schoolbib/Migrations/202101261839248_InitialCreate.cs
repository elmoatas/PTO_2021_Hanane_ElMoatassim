namespace WPF_Schoolbib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Creator = c.String(),
                        ProductNumber = c.Long(nullable: false),
                        Availability = c.Int(nullable: false),
                        Id = c.Int(),
                        Pages = c.Int(),
                        Publisher = c.String(),
                        Language = c.Int(),
                        BookGenre = c.Int(),
                        GenreIndex = c.Int(),
                        Id1 = c.Int(),
                        Duration = c.Int(),
                        Genre = c.String(),
                        CdGenre = c.Int(),
                        Id2 = c.Int(),
                        Duration1 = c.Int(),
                        GenreIndex1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Loaner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.LibraryId)
                .ForeignKey("dbo.Students", t => t.Loaner_Id)
                .Index(t => t.Loaner_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Study = c.String(),
                        Sex = c.String(),
                        Studyindex = c.Int(nullable: false),
                        SexIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoanDate = c.DateTime(nullable: false),
                        Fine = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        itemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libraries", "Loaner_Id", "dbo.Students");
            DropIndex("dbo.Libraries", new[] { "Loaner_Id" });
            DropTable("dbo.Loans");
            DropTable("dbo.Students");
            DropTable("dbo.Libraries");
        }
    }
}

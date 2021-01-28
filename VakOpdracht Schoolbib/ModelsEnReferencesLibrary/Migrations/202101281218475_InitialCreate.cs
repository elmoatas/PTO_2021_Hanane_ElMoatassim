namespace ModelsEnReferencesLibrary.Migrations
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
                        ReserveStudentID = c.Int(nullable: false),
                        LoanerID = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        Id = c.Int(),
                        Pages = c.Int(),
                        Publisher = c.String(),
                        LanguageIndex = c.Int(),
                        GenreIndex = c.Int(),
                        Id1 = c.Int(),
                        Duration = c.Int(),
                        GenreIndex1 = c.Int(),
                        Id2 = c.Int(),
                        Duration1 = c.Int(),
                        LanguageIndex1 = c.Int(),
                        GenreIndex2 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LibraryId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LoanDate = c.DateTime(nullable: false),
                        Fine = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StudentFirstName = c.String(),
                        StudentLastName = c.String(),
                        itemId = c.Int(nullable: false),
                        ItemTitle = c.String(),
                        ItemCreator = c.String(),
                        ItemProductNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Studyindex = c.Int(nullable: false),
                        SexIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.Loans");
            DropTable("dbo.Libraries");
        }
    }
}

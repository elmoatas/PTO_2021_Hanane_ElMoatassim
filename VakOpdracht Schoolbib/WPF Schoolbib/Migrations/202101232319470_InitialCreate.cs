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
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Creator = c.String(),
                        ProductNumber = c.Long(nullable: false),
                        Pages = c.Int(),
                        Publisher = c.String(),
                        Language = c.Int(),
                        BookGenre = c.Int(),
                        GenreIndex = c.Int(),
                        Duration = c.Int(),
                        Genre = c.String(),
                        CdGenre = c.Int(),
                        Duration1 = c.Int(),
                        GenreIndex1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Loaner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libraries", "Loaner_Id", "dbo.Students");
            DropIndex("dbo.Libraries", new[] { "Loaner_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Libraries");
        }
    }
}

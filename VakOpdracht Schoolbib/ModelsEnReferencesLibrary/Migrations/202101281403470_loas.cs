namespace ModelsEnReferencesLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "ReturnDateString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "ReturnDateString");
        }
    }
}

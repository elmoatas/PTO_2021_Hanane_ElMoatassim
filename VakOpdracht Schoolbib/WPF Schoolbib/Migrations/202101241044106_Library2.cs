namespace WPF_Schoolbib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libraries", "LoanDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libraries", "LoanDate");
        }
    }
}

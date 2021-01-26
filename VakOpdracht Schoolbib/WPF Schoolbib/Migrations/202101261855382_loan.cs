namespace WPF_Schoolbib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "ReturnDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "ReturnDate");
        }
    }
}

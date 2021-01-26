namespace WPF_Schoolbib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loan2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Loans", "ReturnDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}
